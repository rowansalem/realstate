using Newtonsoft.Json;
using RealStatesApp.Models;
using RealStatesApp.Services.Employee.Contracts;
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
    }
}
