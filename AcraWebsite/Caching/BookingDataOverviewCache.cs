using System;
using System.Threading;
using System.Threading.Tasks;
using AcraWebsite.Models;
using MohBooking.Client;

namespace AcraWebsite.Caching
{
    public class BookingDataOverviewCache : IBookingDataOverviewCache
    {
        private readonly IMohBookingClient _mohBookingClient;
        private readonly object _dataLocker = new object();

        private BookingDataOverview _cachedData;
        private Thread _loadingThread = null;

        public BookingDataOverviewCache(
            IMohBookingClient mohBookingClient
        )
        {
            _mohBookingClient = mohBookingClient;
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
            BookingDataOverview data = await LoadData();

            lock (_dataLocker)
            {
                _cachedData = data;
                _loadingThread = null;
            }
        }

        private async Task<BookingDataOverview> LoadData()
        {
            //TODO load Data from _mohBookingClient and assign to local variable
            throw new NotImplementedException();
        }
    }
}