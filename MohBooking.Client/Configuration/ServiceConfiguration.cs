using Microsoft.Extensions.DependencyInjection;
using System;

namespace MohBooking.Client
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddMohBookingClientServices(this IServiceCollection services)
        {
            services.AddScoped<IMohBookingClient, MohBookingClient>();

            services.AddHttpClient<MohBookingClient>(o =>
            {
                o.BaseAddress = new Uri("https://booking.moh.gov.ge/Hmis/Hmis.Queue.API/api/");
                o.DefaultRequestHeaders.Add("referer", "https://booking.moh.gov.ge/Hmis/Hmis.Queue.Web/");
                o.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
                o.DefaultRequestHeaders.Add("sec-fetch-dest", "empty");
                o.DefaultRequestHeaders.Add("sec-fetch-mode", "cors");
                o.DefaultRequestHeaders.Add("sec-fetch-site", "same-origin");
                o.DefaultRequestHeaders.Add("securitynumber", "60949641360");
                o.DefaultRequestHeaders.UserAgent.TryParseAdd("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.27 Safari/537.36");
            });

            return services;
        }
    }
}
