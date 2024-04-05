using RealStatesApp.ViewModels;
namespace RealStatesApp
{
    public partial class PropertiesPage : ContentPage
    {
        public PropertiesPage(PropertiesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

        }
    }
}