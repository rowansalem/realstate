using RealStatesApp.ViewModels;

namespace RealStatesApp.Pages.Employees
{
    public partial class EmployeesListPage : ContentPage
    {
        private EmployeesListViewModel _viewModel;

        public EmployeesListPage(EmployeesListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = BindingContext as EmployeesListViewModel;


            MessagingCenter.Subscribe<AddEditEmployeePage>(this, "RefreshEmployeeList", async (sender) =>
            {
                await _viewModel.LoadEmployeesAsync();
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadEmployeesAsync();
        }

    }
}