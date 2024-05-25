using Newtonsoft.Json;
using RealStatesApp.Models;
using RealStatesApp.Services.Address.Contracts;
using RealStatesApp.Services.SalesOffice.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Services.Address
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AddressDTO>> GetAddressAsync()
        {
            var response = await _httpClient.GetAsync($"https://localhost:44338/Address");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<DataListApiResult<AddressDTO>>(content);
            return employees?.DataList;
        }

        public async Task<AddressDTO?> GetAddressByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:44338/Address/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<DataApiResult<AddressDTO>>(content);
            return employee?.Data;
        }

        public async Task<bool?> CreateAddressAsync(AddressDTO employee)
        {
            var employeeJson = JsonConvert.SerializeObject(employee);
            var response = await _httpClient.PostAsync($"https://localhost:44338/Address", new StringContent(employeeJson, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var createdAddress = JsonConvert.DeserializeObject<ApiResult<AddressDTO>>(content);
            return createdAddress?.IsSuccess;
        }   

        public async Task<bool?> UpdateAddressAsync(AddressDTO employee)
        {
            var employeeJson = JsonConvert.SerializeObject(employee);
            var response = await _httpClient.PutAsync($"https://localhost:44338/Address/{employee.Id}", new StringContent(employeeJson, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var updatedAddress = JsonConvert.DeserializeObject<ApiResult<AddressDTO>>(content);
            return updatedAddress?.IsSuccess;
        }


        public async Task<bool?> DeleteAddressAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:44338/Address/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var deletedAddress = JsonConvert.DeserializeObject<ApiResult<AddressDTO>>(content);
            return deletedAddress?.IsSuccess;
        }

    }
}
