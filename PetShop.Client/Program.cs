using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PetShop.App.Services;
using System;
using System.Threading.Tasks;

namespace PetShop.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<PetShop.App.App>("app");

            builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(
                client => client.BaseAddress = new Uri("https://blazorpetshopapi.azurewebsites.net"));

            builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(
                client => client.BaseAddress = new Uri("https://blazorpetshopapi.azurewebsites.net"));

            builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(
                client => client.BaseAddress = new Uri("https://blazorpetshopapi.azurewebsites.net"));


            await builder.Build().RunAsync();
        }
    }
}



