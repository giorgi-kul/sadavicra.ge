using System.Collections.Generic;
using Newtonsoft.Json;

namespace MohBooking.Client
{
    public class ServiceType
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("minAge")]
        public int MinAge { get; set; }

        [JsonProperty("allowed")]
        public int Allowed { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("sameProvider")]
        public bool SameProvider { get; set; }

        [JsonProperty("allowForeigner")]
        public bool AllowForeigner { get; set; }

        [JsonProperty("ignoreAgeWhenDoctor")]
        public bool IgnoreAgeWhenDoctor { get; set; }

        [JsonProperty("minBookingDays")]
        public int MinBookingDays { get; set; }

        [JsonProperty("maxBookingDays")]
        public int MaxBookingDays { get; set; }

        [JsonProperty("immunizationID")]
        public string ImmunizationId { get; set; }
    }
}