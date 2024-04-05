using RealStatesApp.ViewModels;
namespace RealStatesApp
{
    public partial class EmployeesPage : ContentPage
    {
        public EmployeesPage(EmployeesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

        }
    }
}