using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MohBooking.Client
{
    public class Region
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("olD_ID")]
        public double OlDID { get; set; }

        [JsonProperty("parentID")]
        public string ParentID { get; set; }

        [JsonProperty("parent")]
        public Parent Parent { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("craCode")]
        public string CraCode { get; set; }

        [JsonProperty("geoName")]
        public string GeoName { get; set; }

        [JsonProperty("engName")]
        public object EngName { get; set; }

        [JsonProperty("newCode")]
        public string NewCode { get; set; }

        [JsonProperty("typeID")]
        public string TypeID { get; set; }

        [JsonProperty("areaType")]
        public AreaType AreaType { get; set; }

        [JsonProperty("phoneIndexes")]
        public List<object> PhoneIndexes { get; set; }

        [JsonProperty("recordType")]
        public int RecordType { get; set; }

        [JsonProperty("dateCreated")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("dateChanged")]
        public object DateChanged { get; set; }

        [JsonProperty("dateDeleted")]
        public object DateDeleted { get; set; }
    }
    
     public class AreaType
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("geoName")]
        public string GeoName { get; set; }

        [JsonProperty("engName")]
        public string EngName { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("dateCreated")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("dateChanged")]
        public object DateChanged { get; set; }

        [JsonProperty("dateDeleted")]
        public object DateDeleted { get; set; }
    }

    public class PhoneIndexType
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dateCreated")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("dateChanged")]
        public object DateChanged { get; set; }

        [JsonProperty("dateDeleted")]
        public object DateDeleted { get; set; }
    }

    public class PhoneIndex
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("phoneIndexType")]
        public PhoneIndexType PhoneIndexType { get; set; }

        [JsonProperty("dateCreated")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("dateChanged")]
        public object DateChanged { get; set; }

        [JsonProperty("dateDeleted")]
        public object DateDeleted { get; set; }
    }

    public class Parent
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("olD_ID")]
        public object OlDID { get; set; }

        [JsonProperty("parentID")]
        public object ParentID { get; set; }

        [JsonProperty("parent")]
        public object ParentElem { get; set; }

        [JsonProperty("code")]
        public object Code { get; set; }

        [JsonProperty("craCode")]
        public object CraCode { get; set; }

        [JsonProperty("geoName")]
        public string GeoName { get; set; }

        [JsonProperty("engName")]
        public object EngName { get; set; }

        [JsonProperty("newCode")]
        public string NewCode { get; set; }

        [JsonProperty("typeID")]
        public string TypeID { get; set; }

        [JsonProperty("areaType")]
        public AreaType AreaType { get; set; }

        [JsonProperty("phoneIndexes")]
        public List<PhoneIndex> PhoneIndexes { get; set; }

        [JsonProperty("recordType")]
        public int RecordType { get; set; }

        [JsonProperty("dateCreated")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("dateChanged")]
        public object DateChanged { get; set; }

        [JsonProperty("dateDeleted")]
        public object DateDeleted { get; set; }
    }
}