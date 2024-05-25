using RealStatesApp.Models;
using RealStatesApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using RealStatesApp.Services.Employee.Contracts;
using RealStatesApp.Services.SalesOffice.Contracts;

namespace RealStatesApp.ViewModels
{
    public class AddEditEmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IEmployeesService _employeeService;
        private readonly ISalesOfficeService _salesOfficeService;

        private EmployeeDTO _employee;
        public EmployeeDTO Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                if(value.SalesOfficeId != null)
                {
                    SelectedSalesOffice = SalesOffices.FirstOrDefault(x => x.Id == value.SalesOfficeId);
                }

                OnPropertyChanged();
            }
        }

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
                }
            }
        }

        public ObservableCollection<SalesOfficeDTO> SalesOffices { get; } = new ObservableCollection<SalesOfficeDTO>();
        private SalesOfficeDTO _selectedSalesOffice;
        public SalesOfficeDTO SelectedSalesOffice
        {
            get => _selectedSalesOffice;
            set
            {
                _selectedSalesOffice = value;
                Employee.SalesOfficeId = value?.Id;
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

        public AddEditEmployeeViewModel(IEmployeesService employeeService, ISalesOfficeService salesOfficeService)
        {
            _employeeService = employeeService;
            _salesOfficeService = salesOfficeService;
            SaveCommand = new Command(OnSave);
            LoadSalesOffices();
        }

        public void Initialize(EmployeeDTO employee, bool isEdit)
        {
            Employee = employee;
            PageTitle = isEdit ? "Edit Employee" : "Add New Employee";
            ButtonText = isEdit ? "Save Changes" : "Add Employee";
            OnPropertyChanged();
        }

        private async void LoadSalesOffices()
        {
            var salesOffices = await _salesOfficeService.GetSalesOfficesListAsync();
            SalesOffices.Clear();
            foreach (var office in salesOffices)
            {
                SalesOffices.Add(office);
            }
        }

        private async void OnSave()
        {
            if (Employee.Id == Guid.Empty)
            {
                await _employeeService.CreateEmployeeAsync(Employee);
            }
            else
            {
                await _employeeService.UpdateEmployeeAsync(Employee);
            }

            MessagingCenter.Send(this, "RefreshEmployeeList");

            await Shell.Current.GoToAsync("..");
        }

        public Task<EmployeeDTO> GetEmployeeByIdAsync(Guid employeeId)
        {
            return _employeeService.GetEmployeeByIdAsync(employeeId);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
