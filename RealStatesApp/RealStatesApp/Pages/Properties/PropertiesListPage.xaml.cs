
using RealStatesApp.ViewModels;

namespace RealStatesApp.Pages.Properties
{
    public partial class PropertiesListPage : ContentPage
    {
        private PropertiesListViewModel _viewModel;

        public PropertiesListPage(PropertiesListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = BindingContext as PropertiesListViewModel;


            MessagingCenter.Subscribe<AddEditPropertyPage>(this, "RefreshPropertyList", async (sender) =>
            {
                await _viewModel.LoadPropertiesAsync();
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadPropertiesAsync();
        }

    }
}