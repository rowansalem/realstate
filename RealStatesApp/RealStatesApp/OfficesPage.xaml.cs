using RealStatesApp.ViewModels;
namespace RealStatesApp
{
    public partial class OfficesPage : ContentPage
    {
        public OfficesPage(OfficesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

        }
    }
}