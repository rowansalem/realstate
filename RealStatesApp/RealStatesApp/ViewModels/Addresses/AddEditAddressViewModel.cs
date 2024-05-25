using RealStatesApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RealStatesApp.Services.Address.Contracts;
using RealStatesApp.Services.SalesOffice.Contracts;

namespace RealStatesApp.ViewModels
{
    public class AddEditAddressViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IAddressService _addressService;
        private readonly ISalesOfficeService _salesOfficeService;

        private AddressDTO _address;
        public AddressDTO Address
        {
            get => _address;
            set
            {
                _address = value;
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

        public AddEditAddressViewModel(IAddressService addressService)
        {
            _addressService = addressService;
            SaveCommand = new Command(OnSave);
        }

        public void Initialize(AddressDTO address, bool isEdit)
        {
            Address = address;
            PageTitle = isEdit ? "Edit Address" : "Add New Address";
            ButtonText = isEdit ? "Save Changes" : "Add Address";
            OnPropertyChanged();
        }

        private async void OnSave()
        {
            if (Address.Id == Guid.Empty)
            {
                await _addressService.CreateAddressAsync(Address);
            }
            else
            {
                await _addressService.UpdateAddressAsync(Address);
            }

            MessagingCenter.Send(this, "RefreshAddressList");

            await Shell.Current.GoToAsync("..");
        }

        public Task<AddressDTO> GetAddressByIdAsync(Guid addressId)
        {
            return _addressService.GetAddressByIdAsync(addressId);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
