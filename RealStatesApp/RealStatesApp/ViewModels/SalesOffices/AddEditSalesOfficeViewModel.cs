using RealStatesApp.Models;
using RealStatesApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using RealStatesApp.Services.SalesOffice.Contracts;
using RealStatesApp.Services.Address.Contracts;
using RealStatesApp.Services.Employee.Contracts;

namespace RealStatesApp.ViewModels
{
    public class AddEditSalesOfficeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ISalesOfficeService _salesOfficeService;
        private readonly IAddressService _addressService;
        private readonly IEmployeesService _employeeService;

        // Property to hold the SalesOffice object
        private SalesOfficeDTO _salesoffice;
        public SalesOfficeDTO SalesOffice
        {
            get => _salesoffice;
            set
            {
                _salesoffice = value;
                if(value.AddressId != Guid.Empty)
                {
                    SelectedAddress = Addresses.FirstOrDefault(a => a.Id == value.AddressId);
                }
                if(value.ManagerId != Guid.Empty)
                {
                    SelectedManager = Managers.FirstOrDefault(m => m.Id == value.ManagerId);
                }
                OnPropertyChanged();
            }
        }



        // Property to hold the list of Addresses
        public ObservableCollection<AddressDTO> Addresses { get; } = new ObservableCollection<AddressDTO>();
        private AddressDTO _selectedAddress;
        public AddressDTO SelectedAddress
        {
            get => _selectedAddress;
            set
            {
                _selectedAddress = value;
                if (value != null)
                {
                    SalesOffice.AddressId = value.Id;
                }
                OnPropertyChanged();
            }
        }

        // Property to hold the list of Employees
        public ObservableCollection<EmployeeDTO> Managers { get; } = new ObservableCollection<EmployeeDTO>();
        private EmployeeDTO _selectedManager;
        public EmployeeDTO SelectedManager
        {
            get => _selectedManager;
            set
            {
                _selectedManager = value;
                if(value != null)
                {
                SalesOffice.ManagerId = value.Id;
                }
                OnPropertyChanged();
            }
        }


        public ICommand SaveCommand { get; }
        private String _pageTitle;
        public String PageTitle
        {
            get => _pageTitle;
            set
            {
                _pageTitle = value;
                OnPropertyChanged();
            }
        }
        private String _buttonText;
        public string ButtonText
        {
            get => _buttonText;
            set
            {
                _buttonText = value;
                OnPropertyChanged();
            }
        }
        public AddEditSalesOfficeViewModel() : this(new DefaultSalesOfficesService(),new DefaultEmployeesService(),new DefaultAddressService())
        {
        }
        public AddEditSalesOfficeViewModel(ISalesOfficeService salesofficeService,IEmployeesService employeesService,IAddressService addressService)
        {
            _salesOfficeService = salesofficeService;
            _employeeService = employeesService;
            _addressService = addressService;
            SaveCommand = new Command(OnSave);
            LoadAddresses();
            LoadManagers();
        }

        public void Initialize(SalesOfficeDTO salesoffice, bool isEdit)
        {
            SalesOffice = salesoffice;
            PageTitle = isEdit ? "Edit SalesOffice" : "Add New SalesOffice";
            ButtonText = isEdit ? "Save Changes" : "Add SalesOffice";
            OnPropertyChanged();
        }

        private void ClearDataForm()
        {
            SalesOffice = new SalesOfficeDTO();
            SelectedAddress = null;
            SelectedManager = null;
        }
        public void ClearForm()
        {
            ClearDataForm();
        }
        private async void LoadAddresses()
        {
            var addresses = await _addressService.GetAddressAsync();
            Addresses.Clear();
            foreach (var address in addresses)
            {
                Addresses.Add(address);
            }
        }

        private async void LoadManagers()
        {
            var managers = await _employeeService.GetEmployeesAsync();
            Managers.Clear();
            foreach (var manager in managers)
            {
                Managers.Add(manager);
            }
        }

        private async void OnSave()
        {
            if (SalesOffice.Id == Guid.Empty)
            {
                await _salesOfficeService.CreateSalesOfficeAsync(SalesOffice);
            }
            else
            {
                await _salesOfficeService.UpdateSalesOfficeAsync(SalesOffice);
            }

            MessagingCenter.Send(this, "RefreshSalesOfficeList");

            await Shell.Current.GoToAsync("..");
        }

        public Task<SalesOfficeDTO> GetSalesOfficeByIdAsync(Guid salesofficeId)
        {
            return _salesOfficeService.GetSalesOfficeByIdAsync(salesofficeId);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
