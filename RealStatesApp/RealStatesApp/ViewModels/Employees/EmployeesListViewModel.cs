using RealStatesApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using RealStatesApp.Services.Employee.Contracts;
using RealStatesApp.Services.SalesOffice.Contracts;
using RealStatesApp.Pages.Employees;

namespace RealStatesApp.ViewModels
{
    public class EmployeesListViewModel : INotifyPropertyChanged
    {
        // Properties
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IEmployeesService _employeeService;
        private List<EmployeeDTO> _employeesList;
        public ObservableCollection<EmployeeDTO> Employees { get; } = new();
        public List<EmployeeDTO> EmployeesList
        {
            get => _employeesList;
            set
            {
                _employeesList = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AddCommand { get; }

        // Default constructor
        public EmployeesListViewModel() : this(new DefaultEmployeesService())
        {
        }

        // Constructor with dependency injection
        public EmployeesListViewModel(IEmployeesService employeeService)
        {
            _employeeService = employeeService;
            EditCommand = new Command<EmployeeDTO>(OnEdit);
            DeleteCommand = new Command<EmployeeDTO>(OnDelete);
            AddCommand = new Command(OnAdd);

            LoadEmployees();
        }

        // Methods
        private async void LoadEmployees()
        {
            EmployeesList = await _employeeService.GetEmployeesAsync();
            Employees.Clear();
            foreach (var employee in EmployeesList)
            {
                Employees.Add(employee);
            }
        }

        public async Task LoadEmployeesAsync()
        {
            LoadEmployees();
        }

        private async void OnEdit(EmployeeDTO employee)
        {
            var queryParameters = new Dictionary<string, object>
            {
            { "employeeId", employee.Id.ToString() } 
            };
            await Shell.Current.GoToAsync(nameof(AddEditEmployeePage), queryParameters);
        }


        private async void OnDelete(EmployeeDTO employee)
        {
            await _employeeService.DeleteEmployeeAsync(employee.Id);
            await LoadEmployeesAsync();
        }

        private async void OnAdd()
        {
            await Shell.Current.GoToAsync(nameof(AddEditEmployeePage));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Default implementation of IEmployeesService for the default constructor
    public class DefaultEmployeesService : IEmployeesService
    {
        public Task<List<EmployeeDTO>> GetEmployeesAsync()
        {
            return Task.FromResult(new List<EmployeeDTO>());
        }

        public Task<EmployeeDTO?> GetEmployeeByIdAsync(Guid id)
        {
            return Task.FromResult<EmployeeDTO?>(null);
        }

        public Task<bool?> CreateEmployeeAsync(EmployeeDTO employee)
        {
            return Task.FromResult<bool?>(true);
        }

        public Task<bool?> UpdateEmployeeAsync(EmployeeDTO employee)
        {
            return Task.FromResult<bool?>(true);
        }

        public Task<bool?> DeleteEmployeeAsync(Guid id)
        {
            return Task.FromResult<bool?>(true);
        }
    }
}
