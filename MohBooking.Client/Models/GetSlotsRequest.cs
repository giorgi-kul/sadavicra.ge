using System;
using Newtonsoft.Json;

namespace MohBooking.Client
{
    public class GetSlotsRequest
    {
        [JsonProperty("branchID")]
        public string BranchID { get; set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty("regionID")]
        public string RegionID { get; set; }

        [JsonProperty("serviceID")]
        public string ServiceID { get; set; }
    }
}