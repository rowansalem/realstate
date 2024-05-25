using Android.Telephony.Data;
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
        private readonly string _baseUrl;

        public EmployeesService(AppSettings appSettings)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            _httpClient = new HttpClient(handler);
            _baseUrl = appSettings.BaseUrl;
        }

        public async Task<List<EmployeeDTO>> GetEmployeesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/Employee");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<DataListApiResult<EmployeeDTO>>(content);
            return employees?.DataList;
        }

        public async Task<EmployeeDTO?> GetEmployeeByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/Employee/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<DataApiResult<EmployeeDTO>>(content);
            return employee?.Data;
        }

        public async Task<bool?> CreateEmployeeAsync(EmployeeDTO employee)
        {
            var employeeJson = JsonConvert.SerializeObject(employee);
            var response = await _httpClient.PostAsync($"{_baseUrl}/Employee", new StringContent(employeeJson, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var createdEmployee = JsonConvert.DeserializeObject<ApiResult<EmployeeDTO>>(content);
            return createdEmployee?.IsSuccess;
        }   

        public async Task<bool?> UpdateEmployeeAsync(EmployeeDTO employee)
        {
            var employeeJson = JsonConvert.SerializeObject(employee);
            var response = await _httpClient.PutAsync($"{_baseUrl}/Employee/{employee.Id}", new StringContent(employeeJson, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var updatedEmployee = JsonConvert.DeserializeObject<ApiResult<EmployeeDTO>>(content);
            return updatedEmployee?.IsSuccess;
        }


        public async Task<bool?> DeleteEmployeeAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/Employee/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var deletedEmployee = JsonConvert.DeserializeObject<ApiResult<EmployeeDTO>>(content);
            return deletedEmployee?.IsSuccess;
        }

    }
}
