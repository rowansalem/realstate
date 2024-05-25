

using RealStatesApp.Pages.Addresses;
using RealStatesApp.Pages.Employees;
using RealStatesApp.Pages.Owners;
using RealStatesApp.Pages.Properties;
using RealStatesApp.Pages.SalesOffices;

namespace RealStatesApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnPropertiesClickedAsync(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(PropertiesPage));

            SemanticScreenReader.Announce(PropertiesBtn.Text);

        }
        private async void OnEmployeesClickedAsync(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(EmployeesPage));

            SemanticScreenReader.Announce(EmployeesBtn.Text);

        }
        private async void OnOfficesClickedAsync(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(OfficesPage));

            SemanticScreenReader.Announce(OfficesBtn.Text);

        }

        private async void OnEmployeesListClickedAsync(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(EmployeesListPage));

            SemanticScreenReader.Announce(EmployeesListBtn.Text);

        }
        private async void OnAddressesListClickedAsync(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddressesListPage));

            SemanticScreenReader.Announce(AddressesListBtn.Text);

        }
        private async void OnOwnersListClickedAsync(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(OwnersListPage));

            SemanticScreenReader.Announce(OwnersListBtn.Text);

        }
        private async void OnPropertiesListClickedAsync(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(PropertiesListPage));

            SemanticScreenReader.Announce(PropertiesListBtn.Text);

        }
        private async void OnSalesOfficesListClickedAsync(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync(nameof(SalesOfficesListPage));

            //SemanticScreenReader.Announce(SalesOfficesListBtn.Text);

            await Shell.Current.GoToAsync(nameof(OfficesPage));

            SemanticScreenReader.Announce(OfficesBtn.Text);

        }
    }

}
