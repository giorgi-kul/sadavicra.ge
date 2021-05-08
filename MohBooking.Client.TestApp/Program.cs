using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace MohBooking.Client.TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var serviceProvider = ConfigureSevices();

            var client = serviceProvider.GetRequiredService<IMohBookingClient>();

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

        private static ServiceProvider ConfigureSevices()
        {
            var services = new ServiceCollection();
            services.AddMohBookingClientServices();

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}