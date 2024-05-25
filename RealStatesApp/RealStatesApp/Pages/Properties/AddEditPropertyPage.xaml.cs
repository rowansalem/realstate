using RealStatesApp.Models;
using RealStatesApp.Services.Owner.Contracts;
using RealStatesApp.Services.Property.Contracts;
using RealStatesApp.Services.SalesOffice;
using RealStatesApp.Services.SalesOffice.Contracts;
using RealStatesApp.ViewModels;

namespace RealStatesApp.Pages.Properties
{
    [QueryProperty(nameof(PropertyId), "propertyId")]
    public partial class AddEditPropertyPage : ContentPage
    {
        private readonly AddEditPropertyViewModel _viewModel;
        public string PropertyId { get; set; }

        public AddEditPropertyPage(IPropertiesService propertyService, IOwnersService ownersService,ISalesOfficeService salesOfficeService)
        {
            InitializeComponent();
            _viewModel = new AddEditPropertyViewModel(propertyService, ownersService,salesOfficeService);
            BindingContext = _viewModel;
        }

        public AddEditPropertyPage(PropertyDTO property, bool isEdit, IPropertiesService propertyService, IOwnersService ownersService,ISalesOfficeService salesOfficeService)
            : this(propertyService, ownersService, salesOfficeService)
        {
            _viewModel.Initialize(property, isEdit);
        }
        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            if (!string.IsNullOrEmpty(PropertyId))
            {
                var guid = Guid.Parse(PropertyId);
                var property = await _viewModel.GetPropertyByIdAsync(guid);
                _viewModel.Initialize(property, true);
            }
            else
            {
                _viewModel.Initialize(new PropertyDTO(), false);
            }
        }
    }
}