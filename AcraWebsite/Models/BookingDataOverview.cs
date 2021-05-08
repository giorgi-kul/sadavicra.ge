using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcraWebsite.Models
{
    public class BookingDataOverview
    {
        public IEnumerable<Vaccine> Vaccines { get; set; }
    }

    public class Vaccine
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<VaccineLocation> Locations { get; set; }
    }

    public class VaccineLocation
    {
        public string RegionId { get; set; }
        public string RegionName { get; set; }
        public string MunicipalityId { get; set; }
        public string MunicipalityName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public int AvailableSlotCount { get; set; }
    }
}
