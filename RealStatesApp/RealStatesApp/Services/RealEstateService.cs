using Newtonsoft.Json;
using RealStatesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Services
{
    public class RealEstateService : IRealEstateService
    {
        private HttpClient _httpClient;

        public RealEstateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PropertiesPerOfficeDTO?> GetPropertiesPerOfficeAsync(Guid officeId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7074/Reports/PropertiesPerOffice/{officeId}");
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PropertiesPerOfficeDTO>(jsonString);
        }
        
        public async Task<EmployeesByOfficeDTO?> GetEmployeesByOfficeAsync(Guid officeId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7074/Reports/EmployeesByOffice/{officeId}");
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EmployeesByOfficeDTO>(jsonString);
        }
        public async Task<List<OfficePropertyCountDTO>?> GetOfficePropertyCountsAsync()
        {
            var response = await _httpClient.GetAsync($"https://localhost:7074/Reports/OfficePropertyCounts");
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<OfficePropertyCountDTO>>(jsonString);
        }

        public async Task<List<GetOfficeListResponse>> GetOfficesAsync()
        {
            try
            {
                // Adjust the URL to where your actual API endpoint is located
                var response = await _httpClient.GetAsync("https://localhost:7074/SalesOffices");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    // Use System.Text.Json or Newtonsoft.Json to deserialize the response
                    var offices = System.Text.Json.JsonSerializer.Deserialize<List<GetOfficeListResponse>>(json, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return offices != null ? offices : new List<GetOfficeListResponse>();
                }
                else
                {
                    // Handle non-success status here
                    return new List<GetOfficeListResponse>();
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                return new List<GetOfficeListResponse>();
            }
        }
    }
}
