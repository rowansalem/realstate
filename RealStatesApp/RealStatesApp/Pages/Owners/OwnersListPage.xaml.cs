using RealStatesApp.ViewModels;

namespace RealStatesApp.Pages.Owners
{
    public partial class OwnersListPage : ContentPage
    {
        private OwnersListViewModel _viewModel;

        public OwnersListPage(OwnersListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = BindingContext as OwnersListViewModel;


            MessagingCenter.Subscribe<AddEditOwnerPage>(this, "RefreshOwnerList", async (sender) =>
            {
                await _viewModel.LoadOwnersAsync();
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadOwnersAsync();
        }

    }
}