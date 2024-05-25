using Newtonsoft.Json;
using RealStatesApp.Models;
using RealStatesApp.Services.Property.Contracts;
using RealStatesApp.Services.SalesOffice.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Services.Property
{
    public class PropertiesService : IPropertiesService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public PropertiesService(AppSettings appSettings)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            _httpClient = new HttpClient(handler);
            _baseUrl = appSettings.BaseUrl;
        }

        public async Task<List<PropertyDTO>> GetPropertiesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/Property");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var propertys = JsonConvert.DeserializeObject<DataListApiResult<PropertyDTO>>(content);
            return propertys?.DataList;
        }

        public async Task<PropertyDTO?> GetPropertyByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/Property/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var property = JsonConvert.DeserializeObject<DataApiResult<PropertyDTO>>(content);
            return property?.Data;
        }

        public async Task<bool?> CreatePropertyAsync(PropertyDTO property)
        {
            var propertyJson = JsonConvert.SerializeObject(property);
            var response = await _httpClient.PostAsync($"{_baseUrl}/Property", new StringContent(propertyJson, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var createdProperty = JsonConvert.DeserializeObject<ApiResult<PropertyDTO>>(content);
            return createdProperty?.IsSuccess;
        }   

        public async Task<bool?> UpdatePropertyAsync(PropertyDTO property)
        {
            var propertyJson = JsonConvert.SerializeObject(property);
            var response = await _httpClient.PutAsync($"{_baseUrl}/Property/{property.Id}", new StringContent(propertyJson, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var updatedProperty = JsonConvert.DeserializeObject<ApiResult<PropertyDTO>>(content);
            return updatedProperty?.IsSuccess;
        }


        public async Task<bool?> DeletePropertyAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/Property/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var deletedProperty = JsonConvert.DeserializeObject<ApiResult<PropertyDTO>>(content);
            return deletedProperty?.IsSuccess;
        }

    }
}
