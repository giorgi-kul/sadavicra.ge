using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MohBooking.Client
{
    public class MohBookingClient
    {
        private const string BaseUrl = "https://booking.moh.gov.ge/Hmis/Hmis.Queue.API/api/";

        public MohBookingClient()
        {
            //referer: https://booking.moh.gov.ge/Hmis/Hmis.Queue.Web/
            //sec-ch-ua: " Not;A Brand";v="99", "Google Chrome";v="91", "Chromium";v="91"
            //sec-ch-ua-mobile: ?0
            //sec-fetch-dest: empty
            //sec-fetch-mode: cors
            //sec-fetch-site: same-origin
            //securitynumber: 60949641360
            //user-agent: Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.27 Safari/537.36
        }

        public Task<IEnumerable<ServiceType>> GetServiceTypesAsync()
        {
            //CommonData/GetServicesTypes
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Region>> GetRegionsAsync(string serviceId)
        {
            //CommonData/GetRegions?serviceId={serviceId}
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Region>> GetMunicipalitiesAsync(string serviceId, string regionId)
        {
            //CommonData/GetMunicipalities/{regionId}?serviceId={serviceId}
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MunicipalityBranch>> GetMunicipalityBranchesAsync(string serviceId,
            string municipalityId)
        {
            //CommonData/GetMunicipalityBranches/{serviceId}/{municipalityId}
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SlotResponse>> GetSlotsAsync(string serviceId, string regionId, string branchId)
        {
            //POST
            //Booking/GetSlots
//{"branchID":"d676bd9f-4ed5-4000-8a6d-9c7b179618ea","startDate":"2021-05-08T04:12:17.403Z","endDate":"2021-05-23T04:12:17.403Z","regionID":"31520d88-870e-485e-a833-5ca9e20e84fa","serviceID":"d1eef49b-00b9-4760-9525-6100c168e642"}
            var request = new GetSlotsRequest()
            {
                ServiceID = serviceId,
                RegionID = regionId,
                BranchID = branchId,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(31)
            };
            throw new NotImplementedException();
        }
    }
}