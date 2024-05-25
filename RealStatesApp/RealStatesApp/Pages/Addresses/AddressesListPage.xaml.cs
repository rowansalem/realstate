using RealStatesApp.ViewModels;

namespace RealStatesApp.Pages.Addresses
{
    public partial class AddressesListPage : ContentPage
    {
        private AddressListViewModel _viewModel;

        public AddressesListPage(AddressListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = BindingContext as AddressListViewModel;


            MessagingCenter.Subscribe<AddEditAddressPage>(this, "RefreshAddressList", async (sender) =>
            {
                await _viewModel.LoadAddressAsync();
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadAddressAsync();
        }

    }
}