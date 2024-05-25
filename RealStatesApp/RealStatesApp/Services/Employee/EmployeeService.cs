using Newtonsoft.Json;
using RealStatesApp.Models;
using RealStatesApp.Services.Employee.Contracts;
using RealStatesApp.Services.SalesOffice.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Services.Employee
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
            var response = await _httpClient.GetAsync($"https://localhost:44338/Employee");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<DataListApiResult<EmployeeDTO>>(content);
            return employees?.DataList;
        }

        public async Task<EmployeeDTO?> GetEmployeeByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:44338/Employee/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<DataApiResult<EmployeeDTO>>(content);
            return employee?.Data;
        }

        public async Task<bool?> CreateEmployeeAsync(EmployeeDTO employee)
        {
            var employeeJson = JsonConvert.SerializeObject(employee);
            var response = await _httpClient.PostAsync($"https://localhost:44338/Employee", new StringContent(employeeJson, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var createdEmployee = JsonConvert.DeserializeObject<ApiResult<EmployeeDTO>>(content);
            return createdEmployee?.IsSuccess;
        }   

        public async Task<bool?> UpdateEmployeeAsync(EmployeeDTO employee)
        {
            var employeeJson = JsonConvert.SerializeObject(employee);
            var response = await _httpClient.PutAsync($"https://localhost:44338/Employee/{employee.Id}", new StringContent(employeeJson, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var updatedEmployee = JsonConvert.DeserializeObject<ApiResult<EmployeeDTO>>(content);
            return updatedEmployee?.IsSuccess;
        }


        public async Task<bool?> DeleteEmployeeAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:44338/Employee/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var deletedEmployee = JsonConvert.DeserializeObject<ApiResult<EmployeeDTO>>(content);
            return deletedEmployee?.IsSuccess;
        }

    }
}
