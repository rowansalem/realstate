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

        public SalesOfficeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SalesOfficeDTO>> GetSalesOfficesListAsync()
        {
            var response = await _httpClient.GetAsync($"https://localhost:44338/SalesOffices");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var SalesOffices = JsonConvert.DeserializeObject<DataListApiResult<SalesOfficeDTO>>(content);
            return SalesOffices?.DataList;
        }
    }
}
