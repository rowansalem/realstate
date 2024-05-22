using RealStatesApp.ViewModels;
namespace RealStatesApp
{
    public partial class EmployeesListPage : ContentPage
    {
        public EmployeesListPage(EmployeesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

    }
}