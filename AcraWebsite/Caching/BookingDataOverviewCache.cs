using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AcraWebsite.Models;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.Extensions.Logging;
using MohBooking.Client;

namespace AcraWebsite.Caching
{
    public class BookingDataOverviewCache : IBookingDataOverviewCache
    {
        private readonly IMohBookingClient _mohBookingClient;
        private readonly ILogger<BookingDataOverviewCache> _logger;
        private readonly object _dataLocker = new object();

        private BookingDataOverview _cachedData;
        private Thread _loadingThread = null;

        public BookingDataOverviewCache(
            IMohBookingClient mohBookingClient,
            ILogger<BookingDataOverviewCache> logger
        )
        {
            _mohBookingClient = mohBookingClient;
            _logger = logger;
            InitiateDataReload();
        }

        public BookingDataOverview GetAllData()
        {
            lock (_dataLocker)
                return _cachedData;
        }

        public void InitiateDataReload()
        {
            lock (_dataLocker)
            {
                if (_loadingThread != null)
                    return;

                _loadingThread = new Thread(async () => await LoadingThreadWorker());
                _loadingThread.Start();
            }
        }

        private async Task LoadingThreadWorker()
        {
            BookingDataOverview data;
            try
            {
                data = await LoadData();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load data from MOH");
                return;
            }

            lock (_dataLocker)
            {
                _cachedData = data;
                _loadingThread = null;
            }
        }

        private async Task<BookingDataOverview> LoadData()
        {
            var model = new BookingDataOverview();
            model.Vaccines = new List<Vaccine>();

            var vaccines = await _mohBookingClient.GetServicesAsync();
            foreach (var vaccine in vaccines)
            {
                var vaccineModel = new Vaccine()
                {
                    Id = vaccine.Id,
                    Name = vaccine.Name,
                    Description = "", //TODO: implemnet warning messages for Pfizer and AstraZeneka
                    Municipalities = new List<Municipality>()
                };
                model.Vaccines.Add(vaccineModel);

                var regions = await _mohBookingClient.GetRegionsAsync(vaccine.Id);
                foreach (var region in regions)
                {
                    var municipalities = await _mohBookingClient.GetMunicipalitiesAsync(vaccine.Id, region.Id);
                    foreach (var municipality in municipalities)
                    {
                        var municipalityModel = new Municipality()
                        {
                            RegionId = region.Id,
                            RegionName = region.GeoName,
                            Id = municipality.Id,
                            Name = municipality.GeoName,
                            Locations = new List<VaccineLocation>()
                        };

                        var branches = await _mohBookingClient.GetMunicipalityBranchesAsync(vaccine.Id, municipality.Id);
                        foreach (var branch in branches)
                        {
                            var slots = await _mohBookingClient.GetSlotsAsync(vaccine.Id, region.Id, branch.Id);
                            if (!slots.Any())
                                continue;

                            var modelLocation = new VaccineLocation()
                            {
                                BranchId = branch.Id,
                                BranchName = branch.Name,
                                BranchAddress = branch.Address,
                                AvailableCount = slots.Count()
                            };
                            municipalityModel.Locations.Add(modelLocation);
                        }

                        if (municipalityModel.AvailableCount > 0)
                            vaccineModel.Municipalities.Add(municipalityModel);
                    }
                }
            }

            model.LastUpdateDt = DateTimeOffset.UtcNow;

            return model;
        }
    }
}