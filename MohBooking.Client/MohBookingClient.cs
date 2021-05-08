using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MohBooking.Client
{
    public class MohBookingClient
    {
        private readonly HttpClient _httpClient;

        public MohBookingClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<ServiceType>> GetServiceTypesAsync()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "CommonData/GetServicesTypes");
            return ProcessRequestAsync<IEnumerable<ServiceType>>(requestMessage);
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

        private async Task<TResult> ProcessRequestAsync<TResult>(HttpRequestMessage requestMessage)
        {
            var responseMessage = await _httpClient.SendAsync(requestMessage);
            responseMessage.EnsureSuccessStatusCode();
            var responseContent = await responseMessage.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<TResult>(responseContent);
            return responseData;
        }
    }
}