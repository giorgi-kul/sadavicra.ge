using System;
using Newtonsoft.Json;

namespace MohBooking.Client
{
    public class GetSlotsRequest
    {
        [JsonProperty("branchID")]
        public string BranchId { get; set; }

        [JsonProperty("startDate")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime? EndDate { get; set; }

        [JsonProperty("regionID")]
        public string RegionId { get; set; }

        [JsonProperty("serviceID")]
        public string ServiceId { get; set; }
    }
}