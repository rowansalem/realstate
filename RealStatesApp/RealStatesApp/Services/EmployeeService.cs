using Newtonsoft.Json;
using RealStatesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly HttpClient _httpClient;

        public EmployeesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeDTO>> GetEmployeesAsync()
        {
            var response = await _httpClient.GetAsync($"https://localhost:7074/Employee");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<List<EmployeeDTO>>(content);
            return employees;
        }
    }
}
