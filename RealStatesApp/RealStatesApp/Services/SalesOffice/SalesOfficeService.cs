using Newtonsoft.Json;
using RealStatesApp.Models;
using RealStatesApp.Services.SalesOffice.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Services.SalesOffice
{
    public class SalesOfficeService : ISalesOfficeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public SalesOfficeService(AppSettings appSettings)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            _httpClient = new HttpClient(handler);
            _baseUrl = appSettings.BaseUrl;

        }

        public async Task<List<SalesOfficeDTO>> GetSalesOfficesListAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/SalesOffices");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var SalesOffices = JsonConvert.DeserializeObject<DataListApiResult<SalesOfficeDTO>>(content);
            return SalesOffices?.DataList;
        }


        public async Task<SalesOfficeDTO?> GetSalesOfficeByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/SalesOffice/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var salesoffice = JsonConvert.DeserializeObject<DataApiResult<SalesOfficeDTO>>(content);
            return salesoffice?.Data;
        }

        public async Task<bool?> CreateSalesOfficeAsync(SalesOfficeDTO salesoffice)
        {
            var salesofficeJson = JsonConvert.SerializeObject(salesoffice);
            var response = await _httpClient.PostAsync($"{_baseUrl}/SalesOffice", new StringContent(salesofficeJson, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var createdSalesOffice = JsonConvert.DeserializeObject<ApiResult<SalesOfficeDTO>>(content);
            return createdSalesOffice?.IsSuccess;
        }

        public async Task<bool?> UpdateSalesOfficeAsync(SalesOfficeDTO salesoffice)
        {
            var salesofficeJson = JsonConvert.SerializeObject(salesoffice);
            var response = await _httpClient.PutAsync($"{_baseUrl}/SalesOffice/{salesoffice.Id}", new StringContent(salesofficeJson, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var updatedSalesOffice = JsonConvert.DeserializeObject<ApiResult<SalesOfficeDTO>>(content);
            return updatedSalesOffice?.IsSuccess;
        }


        public async Task<bool?> DeleteSalesOfficeAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/SalesOffice/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var deletedSalesOffice = JsonConvert.DeserializeObject<ApiResult<SalesOfficeDTO>>(content);
            return deletedSalesOffice?.IsSuccess;
        }

    }
}
