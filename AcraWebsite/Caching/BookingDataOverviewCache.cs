using System;
using System.Collections.Generic;
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

            var mockModel = new BookingDataOverview();
            mockModel.LastUpdateDt = DateTimeOffset.UtcNow;
            mockModel.Vaccines = new Vaccine[]
            {
                new Vaccine()
                {
                    Name = "კოვიდ 19 ვაქცინაცია (AstraZeneca)",
                    Description = "5 მაისიდან 20.00 სთ-დან იწყება ასტრაზენეკას მე-2 დოზაზე რეგისტრაცია. აცრის ჩატარება შესაძლებელი იქნება 10 მაისიდან. თქვენ შეგიძლიათ დარეგისტრირდეთ მე-2 დოზის მისაღებად ნებისმიერ დაწესებულებაში პირველი აცრიდან 4 - 12 კვირის ინტერვალში. ასაკობრივი შეზღუდვა არ ვრცელდება მათზე, ვინც პირველი დოზით აცრა ჩაიტარა ასტრაზენეკას ვაქცინით. \n დამატებითი ფანჯრები ეტაპობრივად გაიხსნება"
                },
                new Vaccine()
                {
                    Name = "კოვიდ 19 ვაქცინაცია (Sinopharm)",
                    Municipalities = new Municipality[]
                    {
                        new Municipality()
                        {
                            Name = "ხულო",
                            RegionName =  "აჭარა",
                            Locations = new VaccineLocation[]
                            {
                                new VaccineLocation()
                                {
                                    BranchName = "სს \"ევექსის კლინიკები\"-ხულოს კლინიკა",
                                    BranchAddress = "აღმაშენებლის ქ.N1",
                                    AvailableCount =  1
                                }
                            }
                        }
                    }
                }
            };

            return mockModel;
        }
    }
}