using PetShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetShop.App.Services
{
    public class JobCategoryDataService : IJobCategoryDataService
    {
        private readonly HttpClient _httpClient;

        private JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public JobCategoryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<JobCategory>> GetAllJobCategories()
        {
            var results = await _httpClient.GetStreamAsync("api/jobcategory");

            return await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>(results, _jsonSerializerOptions);
        }

        public async Task<JobCategory> GetJobCategoryById(int jobCategoryId)
        {
            var result = await _httpClient.GetStreamAsync("api/jobcategory/" + jobCategoryId);

            return await JsonSerializer.DeserializeAsync<JobCategory>(result, _jsonSerializerOptions);
        }
    }
}
