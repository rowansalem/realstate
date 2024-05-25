using RealStatesApp.Models;
using RealStatesApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System;
using System.Linq;
using System.Threading.Tasks;
using RealStatesApp.Services.Property.Contracts;
using RealStatesApp.Services.Owner.Contracts;
using RealStatesApp.Services.SalesOffice.Contracts;

namespace RealStatesApp.ViewModels
{
    public class AddEditPropertyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IPropertiesService _propertyService;
        private readonly IOwnersService _ownersService;
        private readonly ISalesOfficeService _salesOfficeService;

        private PropertyDTO _property;
        public PropertyDTO Property
        {
            get => _property;
            set
            {
                _property = value;
                if (_property?.PropertyOwners != null)
                {
                    Owners.ToList().ForEach(x => {
                        x.IsSelected = _property.PropertyOwners.Select(o => o.Id).Contains(x.Id);
                    });
                }
                if(_property?.SalesOffice != null)
                {
                    SelectedSalesOffice = SalesOffices.FirstOrDefault(x => x.Id == value.SalesOffice.Id);
                }
                OnPropertyChanged();
            }
        }

        public List<string> StatusOptions { get; } = new List<string> { "For Sale", "For Rent" };


        public ObservableCollection<SalesOfficeDTO> SalesOffices { get; } = new ObservableCollection<SalesOfficeDTO>();
        private SalesOfficeDTO _selectedSalesOffice;
        public SalesOfficeDTO SelectedSalesOffice
        {
            get => _selectedSalesOffice;
            set
            {
                _selectedSalesOffice = value;
                Property.SalesOfficeId = value?.Id;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<OwnerDTO> Owners { get; } = new ObservableCollection<OwnerDTO>();
   

        public ICommand SaveCommand { get; }
        private string _pageTitle;
        public string PageTitle
        {
            get => _pageTitle;
            set
            {
                _pageTitle = value;
                OnPropertyChanged();
            }
        }
        private string _buttonText;
        public string ButtonText
        {
            get => _buttonText;
            set
            {
                _buttonText = value;
                OnPropertyChanged();
            }
        }
        public AddEditPropertyViewModel() : this(new DefaultPropertiesService(), new DefaultOwnersService(), new DefaultSalesOfficesService())
        {
        }

        public AddEditPropertyViewModel(IPropertiesService propertyService, IOwnersService ownersService, ISalesOfficeService salesOfficeService)
        {
            _propertyService = propertyService;
            _ownersService = ownersService;
            _salesOfficeService = salesOfficeService;
            SaveCommand = new Command(OnSave);
            LoadOwners();
            LoadSalesOffices();
        }

        public void Initialize(PropertyDTO property, bool isEdit)
        {
            Property = property;
            PageTitle = isEdit ? "Edit Property" : "Add New Property";
            ButtonText = isEdit ? "Save Changes" : "Add Property";
            OnPropertyChanged();
        }

        private async void LoadOwners()
        {
      
            var owners = await _ownersService.GetOwnersAsync();
            Owners.Clear();
            foreach (var owner in owners)
            {
                Owners.Add(owner);
            }

            
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
            if (Property.Id == Guid.Empty)
            {
                Property.OwnersId = Owners.Where(x => x.IsSelected).Select(x=>x.Id).ToList();
                await _propertyService.CreatePropertyAsync(Property);
            }
            else
            {
                await _propertyService.UpdatePropertyAsync(Property);
            }

            MessagingCenter.Send(this, "RefreshPropertyList");

            await Shell.Current.GoToAsync("..");
        }
     
        public Task<PropertyDTO> GetPropertyByIdAsync(Guid propertyId)
        {
            return _propertyService.GetPropertyByIdAsync(propertyId);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

  
}
