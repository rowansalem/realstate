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
    public class PropertiesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PropertyDTO> Properties { get; } = new();

        private readonly IRealEstateService _realEstateService;
        private GetOfficeListResponse _selectedOffice;
        public ObservableCollection<GetOfficeListResponse> Offices { get; } = new();
        public GetOfficeListResponse SelectedOffice
        {
            get => _selectedOffice;
            set
            {
                if (_selectedOffice != value)
                {
                    _selectedOffice = value;
                    OnPropertyChanged();
                    LoadPropertiesAsync();
                }
            }
        }
        public PropertiesViewModel(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
            LoadOfficesAsync();

        }
        private async void LoadOfficesAsync()
        {
            var offices = await _realEstateService.GetOfficesAsync();
            foreach (var office in offices)
            {
                Offices.Add(office);
            }
        }

        async void LoadPropertiesAsync()
        {
            var propertiesPerOffice = await _realEstateService.GetPropertiesPerOfficeAsync(SelectedOffice.OfficeId); // Example GUID
            Properties.Clear();
            foreach (var property in propertiesPerOffice.Properties)
            {
                Properties.Add(property);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
