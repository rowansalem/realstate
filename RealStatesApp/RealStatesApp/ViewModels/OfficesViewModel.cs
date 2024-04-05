using RealStatesApp.Models;
using RealStatesApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.ViewModels
{
    public class OfficesViewModel 
    {

        private readonly IRealEstateService _realEstateService;
        private GetOfficeListResponse _selectedOffice;
        public ObservableCollection<OfficePropertyCountDTO> Offices { get; } = new();

        public OfficesViewModel(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
            LoadOfficesAsync();

        }
        private async void LoadOfficesAsync()
        {
            var offices = await _realEstateService.GetOfficePropertyCountsAsync();

            Offices.Clear();
            if (offices != null)
            {
                foreach (var office in offices)
                {
                    Offices.Add(office);
                }
            }
        }

       
    }
}
