using RealStatesApp.Models;
using RealStatesApp.ViewModels;

namespace RealStatesApp.Pages.Addresses
{
    [QueryProperty(nameof(AddressId), "addressId")]
    public partial class AddEditAddressPage : ContentPage
    {
        private readonly AddEditAddressViewModel _viewModel;
        public string AddressId { get; set; }

        public AddEditAddressPage(AddEditAddressViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            if (!string.IsNullOrEmpty(AddressId))
            {
                var guid = Guid.Parse(AddressId);
                var employee = await _viewModel.GetAddressByIdAsync(guid);
                _viewModel.Initialize(employee, true);
            }
            else
            {
                _viewModel.Initialize(new AddressDTO() { AddressLine= ""}, false);
            }
        }
    }
}