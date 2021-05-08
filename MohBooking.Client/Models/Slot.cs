using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MohBooking.Client
{
    public class SlotResponse
    {
        [JsonProperty("roomID")]
        public string RoomID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("onlyQueue")]
        public bool OnlyQueue { get; set; }

        [JsonProperty("schedules")]
        public List<Schedule> Schedules { get; set; }
    }
    
    public class Slot
    {
        [JsonProperty("organizationID")]
        public string OrganizationID { get; set; }

        [JsonProperty("branchID")]
        public string BranchID { get; set; }

        [JsonProperty("personID")]
        public object PersonID { get; set; }

        [JsonProperty("scheduleDate")]
        public DateTime ScheduleDate { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("roomID")]
        public string RoomID { get; set; }

        [JsonProperty("taken")]
        public bool Taken { get; set; }

        [JsonProperty("reserved")]
        public bool Reserved { get; set; }

        [JsonProperty("scheduleDateTicks")]
        public object ScheduleDateTicks { get; set; }

        [JsonProperty("scheduleDateName")]
        public string ScheduleDateName { get; set; }
    }

    public class Date
    {
        [JsonProperty("organizationID")]
        public string OrganizationID { get; set; }

        [JsonProperty("branchID")]
        public string BranchID { get; set; }

        [JsonProperty("personID")]
        public object PersonID { get; set; }

        [JsonProperty("roomID")]
        public string RoomID { get; set; }

        [JsonProperty("dateTicks")]
        public object DateTicks { get; set; }

        [JsonProperty("date")]
        public DateTime Dt { get; set; }

        [JsonProperty("weekName")]
        public string WeekName { get; set; }

        [JsonProperty("dateName")]
        public string DateName { get; set; }

        [JsonProperty("slots")]
        public List<Slot> Slots { get; set; }
    }

    public class Schedule
    {
        [JsonProperty("roomID")]
        public string RoomID { get; set; }

        [JsonProperty("organizationID")]
        public string OrganizationID { get; set; }

        [JsonProperty("branchID")]
        public string BranchID { get; set; }

        [JsonProperty("personID")]
        public object PersonID { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public object Title { get; set; }

        [JsonProperty("dates")]
        public List<Date> Dates { get; set; }
    }
}