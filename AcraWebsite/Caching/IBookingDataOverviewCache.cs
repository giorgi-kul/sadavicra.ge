using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcraWebsite.Models;

namespace AcraWebsite.Caching
{
    public interface IBookingDataOverviewCache
    {
        BookingDataOverview GetAllData();
        void InitiateDataReload();
    }
}
