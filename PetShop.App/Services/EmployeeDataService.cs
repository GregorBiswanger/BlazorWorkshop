using PetShop.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetShop.App.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient _httpClient;

        private JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true 
        };

        public EmployeeDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var results = await _httpClient.GetStreamAsync("api/employee");

            return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(results, _jsonSerializerOptions);
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var result = await _httpClient.GetStreamAsync("api/employee/" + employeeId);

            return await JsonSerializer.DeserializeAsync<Employee>(result, _jsonSerializerOptions);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var employeeJson = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/employee", employeeJson);

            if(response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteEmployee(int employeeId)
        {
            await _httpClient.DeleteAsync("api/employee/" + employeeId);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var employeeJson = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/employee", employeeJson);
        }
    }
}





