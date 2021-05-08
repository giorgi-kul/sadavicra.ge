using System;
using System.Threading.Tasks;
using System.Linq;

namespace MohBooking.Client.TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new MohBookingClient();
            
            var serviceTypes = await client.GetServiceTypesAsync();
            var service = serviceTypes.Last();
            
            var regions = await client.GetRegionsAsync(service.Id);
            var region = regions.First();
            
            var municipalities = await client.GetMunicipalitiesAsync(service.Id, region.Id);
            var municipality = municipalities.First();
            
            var branches = await client.GetMunicipalityBranchesAsync(service.Id, municipality.Id);
            var branch = branches.First();

            var slots = await client.GetSlotsAsync(service.Id, region.Id, branch.Id);
        }
    }
}