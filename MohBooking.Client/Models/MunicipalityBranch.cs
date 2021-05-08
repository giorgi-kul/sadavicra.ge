using Newtonsoft.Json;

namespace MohBooking.Client
{
    public class MunicipalityBranch
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("parentID")]
        public string ParentId { get; set; }

        [JsonProperty("tax")]
        public string Tax { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("regionID")]
        public string RegionId { get; set; }

        [JsonProperty("municipality")]
        public string Municipality { get; set; }

        [JsonProperty("municipalityID")]
        public string MunicipalityId { get; set; }

        [JsonProperty("settlement")]
        public string Settlement { get; set; }

        [JsonProperty("settlementID")]
        public string SettlementId { get; set; }

    }
}