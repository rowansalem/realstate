using Newtonsoft.Json;
using RealStatesApp.Models;
using RealStatesApp.Services.Employee.Contracts;
using RealStatesApp.Services.Owner.Contracts;
using RealStatesApp.Services.SalesOffice.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Services.Owner
{
    public class OwnersService : IOwnersService
    {
        private readonly HttpClient _httpClient;

        public OwnersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<OwnerDTO>> GetOwnersAsync()
        {
            var response = await _httpClient.GetAsync($"https://localhost:44338/Owner");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var owners = JsonConvert.DeserializeObject<DataListApiResult<OwnerDTO>>(content);
            return owners?.DataList;
        }

        public async Task<OwnerDTO?> GetOwnerByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:44338/Owner/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var owner = JsonConvert.DeserializeObject<DataApiResult<OwnerDTO>>(content);
            return owner?.Data;
        }

        public async Task<bool?> CreateOwnerAsync(OwnerDTO owner)
        {
            var ownerJson = JsonConvert.SerializeObject(owner);
            var response = await _httpClient.PostAsync($"https://localhost:44338/Owner", new StringContent(ownerJson, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var createdOwner = JsonConvert.DeserializeObject<ApiResult<OwnerDTO>>(content);
            return createdOwner?.IsSuccess;
        }   

        public async Task<bool?> UpdateOwnerAsync(OwnerDTO owner)
        {
            var ownerJson = JsonConvert.SerializeObject(owner);
            var response = await _httpClient.PutAsync($"https://localhost:44338/Owner/{owner.Id}", new StringContent(ownerJson, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var updatedOwner = JsonConvert.DeserializeObject<ApiResult<OwnerDTO>>(content);
            return updatedOwner?.IsSuccess;
        }


        public async Task<bool?> DeleteOwnerAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:44338/Owner/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var deletedOwner = JsonConvert.DeserializeObject<ApiResult<OwnerDTO>>(content);
            return deletedOwner?.IsSuccess;
        }

    }
}
