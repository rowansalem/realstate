

using RealStatesApp.Pages.Employees;

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
    }

}
