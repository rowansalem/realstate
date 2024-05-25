using RealStatesApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RealStatesApp.Services.Address.Contracts;
using RealStatesApp.Pages.Addresses;

namespace RealStatesApp.ViewModels
{
    public class AddressListViewModel : INotifyPropertyChanged
    {
        // Properties
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IAddressService _addressService;
        private List<AddressDTO> _addresssList;
        public ObservableCollection<AddressDTO> Address { get; } = new();
        public List<AddressDTO> AddressList
        {
            get => _addresssList;
            set
            {
                _addresssList = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AddCommand { get; }

        // Default constructor
        public AddressListViewModel() : this(new DefaultAddressService())
        {
        }

        // Constructor with dependency injection
        public AddressListViewModel(IAddressService addressService)
        {
            _addressService = addressService;
            EditCommand = new Command<AddressDTO>(OnEdit);
            DeleteCommand = new Command<AddressDTO>(OnDelete);
            AddCommand = new Command(OnAdd);

            LoadAddress();
        }

        // Methods
        private async void LoadAddress()
        {
            AddressList = await _addressService.GetAddressAsync();
            Address.Clear();
            foreach (var address in AddressList)
            {
                Address.Add(address);
            }
        }

        public async Task LoadAddressAsync()
        {
            LoadAddress();
        }

        private async void OnEdit(AddressDTO address)
        {
            var queryParameters = new Dictionary<string, object>
            {
            { "addressId", address.Id.ToString() } 
            };
            await Shell.Current.GoToAsync(nameof(AddEditAddressPage), queryParameters);
        }


        private async void OnDelete(AddressDTO address)
        {
            await _addressService.DeleteAddressAsync(address.Id);
            await LoadAddressAsync();
        }

        private async void OnAdd()
        {
            await Shell.Current.GoToAsync(nameof(AddEditAddressPage));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Default implementation of IAddressService for the default constructor
    public class DefaultAddressService : IAddressService
    {
        public Task<List<AddressDTO>> GetAddressAsync()
        {
            return Task.FromResult(new List<AddressDTO>());
        }

        public Task<AddressDTO?> GetAddressByIdAsync(Guid id)
        {
            return Task.FromResult<AddressDTO?>(null);
        }

        public Task<bool?> CreateAddressAsync(AddressDTO address)
        {
            return Task.FromResult<bool?>(true);
        }

        public Task<bool?> UpdateAddressAsync(AddressDTO address)
        {
            return Task.FromResult<bool?>(true);
        }

        public Task<bool?> DeleteAddressAsync(Guid id)
        {
            return Task.FromResult<bool?>(true);
        }
    }
}
