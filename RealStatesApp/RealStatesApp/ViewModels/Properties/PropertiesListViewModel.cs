using RealStatesApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using RealStatesApp.Services.Property.Contracts;
using RealStatesApp.Services.SalesOffice.Contracts;
using RealStatesApp.Pages.Properties;

namespace RealStatesApp.ViewModels
{
    public class PropertiesListViewModel : INotifyPropertyChanged
    {
        // Properties
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IPropertiesService _propertyService;
        private List<PropertyDTO> _propertysList;
        public ObservableCollection<PropertyDTO> Properties { get; } = new();
        public List<PropertyDTO> PropertiesList
        {
            get => _propertysList;
            set
            {
                _propertysList = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AddCommand { get; }

        // Default constructor
        public PropertiesListViewModel() : this(new DefaultPropertiesService())
        {
        }

        // Constructor with dependency injection
        public PropertiesListViewModel(IPropertiesService propertyService)
        {
            _propertyService = propertyService;
            EditCommand = new Command<PropertyDTO>(OnEdit);
            DeleteCommand = new Command<PropertyDTO>(OnDelete);
            AddCommand = new Command(OnAdd);

            LoadProperties();
        }

        // Methods
        private async void LoadProperties()
        {
            PropertiesList = await _propertyService.GetPropertiesAsync();
            Properties.Clear();
            foreach (var property in PropertiesList)
            {
                Properties.Add(property);
            }
        }

        public async Task LoadPropertiesAsync()
        {
            LoadProperties();
        }

        private async void OnEdit(PropertyDTO property)
        {
            var queryParameters = new Dictionary<string, object>
            {
            { "propertyId", property.Id.ToString() } 
            };
            await Shell.Current.GoToAsync(nameof(AddEditPropertyPage), queryParameters);
        }


        private async void OnDelete(PropertyDTO property)
        {
            await _propertyService.DeletePropertyAsync(property.Id);
            await LoadPropertiesAsync();
        }

        private async void OnAdd()
        {
            await Shell.Current.GoToAsync(nameof(AddEditPropertyPage));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Default implementation of IPropertiesService for the default constructor
    public class DefaultPropertiesService : IPropertiesService
    {
        public Task<List<PropertyDTO>> GetPropertiesAsync()
        {
            return Task.FromResult(new List<PropertyDTO>());
        }

        public Task<PropertyDTO?> GetPropertyByIdAsync(Guid id)
        {
            return Task.FromResult<PropertyDTO?>(null);
        }

        public Task<bool?> CreatePropertyAsync(PropertyDTO property)
        {
            return Task.FromResult<bool?>(true);
        }

        public Task<bool?> UpdatePropertyAsync(PropertyDTO property)
        {
            return Task.FromResult<bool?>(true);
        }

        public Task<bool?> DeletePropertyAsync(Guid id)
        {
            return Task.FromResult<bool?>(true);
        }
    }
}
