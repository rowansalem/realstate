using RealStatesApp.ViewModels;

namespace RealStatesApp.Pages.SalesOffices
{
    public partial class SalesOfficesListPage : ContentPage
    {
        private SalesOfficesListViewModel _viewModel;

        public SalesOfficesListPage(SalesOfficesListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = BindingContext as SalesOfficesListViewModel;


            MessagingCenter.Subscribe<AddEditSalesOfficePage>(this, "RefreshSalesOfficeList", async (sender) =>
            {
                await _viewModel.LoadSalesOfficesAsync();
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadSalesOfficesAsync();
        }

    }
}