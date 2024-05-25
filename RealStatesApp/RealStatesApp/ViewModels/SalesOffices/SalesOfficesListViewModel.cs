

using RealStatesApp.Models;
using RealStatesApp.Services.SalesOffice.Contracts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RealStatesApp.ViewModels
{
    public class SalesOfficesListViewModel : INotifyPropertyChanged
    {
        // Properties
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ISalesOfficeService _salesofficeService;
        private List<SalesOfficeDTO> _salesofficesList;
        public ObservableCollection<SalesOfficeDTO> SalesOffices { get; } = new();
        public List<SalesOfficeDTO> SalesOfficesList
        {
            get => _salesofficesList;
            set
            {
                _salesofficesList = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AddCommand { get; }

        // Default constructor
        public SalesOfficesListViewModel() : this(new DefaultSalesOfficesService())
        {
        }

        // Constructor with dependency injection
        public SalesOfficesListViewModel(ISalesOfficeService salesofficeService)
        {
            _salesofficeService = salesofficeService;
            EditCommand = new Command<SalesOfficeDTO>(OnEdit);
            DeleteCommand = new Command<SalesOfficeDTO>(OnDelete);
            AddCommand = new Command(OnAdd);

            LoadSalesOffices();
        }

        // Methods
        private async void LoadSalesOffices()
        {
            SalesOfficesList = await _salesofficeService.GetSalesOfficesListAsync();
            SalesOffices.Clear();
            foreach (var salesoffice in SalesOfficesList)
            {
                SalesOffices.Add(salesoffice);
            }
        }

        public async Task LoadSalesOfficesAsync()
        {
            LoadSalesOffices();
        }

        private async void OnEdit(SalesOfficeDTO salesoffice)
        {
            var queryParameters = new Dictionary<string, object>
            {
            { "salesofficeId", salesoffice.Id.ToString() } 
            };
            //await Shell.Current.GoToAsync(nameof(AddEditSalesOfficePage), queryParameters);
        }


        private async void OnDelete(SalesOfficeDTO salesoffice)
        {
            //await _salesofficeService.DeleteSalesOfficeAsync(salesoffice.Id);
            await LoadSalesOfficesAsync();
        }

        private async void OnAdd()
        {
            //await Shell.Current.GoToAsync(nameof(AddEditSalesOfficePage));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Default implementation of ISalesOfficeService for the default constructor
    public class DefaultSalesOfficesService : ISalesOfficeService
    {
        public Task<List<SalesOfficeDTO>> GetSalesOfficesListAsync()
        {
            return Task.FromResult(new List<SalesOfficeDTO>());
        }

        public Task<SalesOfficeDTO?> GetSalesOfficeByIdAsync(Guid id)
        {
            return Task.FromResult<SalesOfficeDTO?>(null);
        }

        public Task<bool?> CreateSalesOfficeAsync(SalesOfficeDTO salesoffice)
        {
            return Task.FromResult<bool?>(true);
        }

        public Task<bool?> UpdateSalesOfficeAsync(SalesOfficeDTO salesoffice)
        {
            return Task.FromResult<bool?>(true);
        }

        public Task<bool?> DeleteSalesOfficeAsync(Guid id)
        {
            return Task.FromResult<bool?>(true);
        }
    }
}
