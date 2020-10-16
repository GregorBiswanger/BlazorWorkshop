using PetShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetShop.App.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient _httpClient;

        private JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public CountryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            var results = await _httpClient.GetStreamAsync("api/country");

            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>(results, _jsonSerializerOptions);
        }

        public async Task<Country> GetCountryById(int countryId)
        {
            var result = await _httpClient.GetStreamAsync("api/country/" + countryId);

            return await JsonSerializer.DeserializeAsync<Country>(result, _jsonSerializerOptions);
        }
    }
}














