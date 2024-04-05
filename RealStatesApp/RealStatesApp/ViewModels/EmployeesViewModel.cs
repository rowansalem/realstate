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
    public class EmployeesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<EmployeeDTO> Employees { get; } = new();

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
                    LoadEmployeesAsync();
                }
            }
        }
        public EmployeesViewModel(IRealEstateService realEstateService)
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

        async void LoadEmployeesAsync()
        {
            var employeesByOffice = await _realEstateService.GetEmployeesByOfficeAsync(SelectedOffice.OfficeId);
            Employees.Clear();
            if (employeesByOffice != null)
            {
                foreach (var property in employeesByOffice.Employees)
                {
                    Employees.Add(property);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
