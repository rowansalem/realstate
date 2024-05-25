using RealStatesApp.Models;
using RealStatesApp.ViewModels;

namespace RealStatesApp.Pages.SalesOffices
{
    [QueryProperty(nameof(SalesOfficeId), "salesofficeId")]
    public partial class AddEditSalesOfficePage : ContentPage
    {
        private readonly AddEditSalesOfficeViewModel _viewModel;
        public string SalesOfficeId { get; set; }

        public AddEditSalesOfficePage(AddEditSalesOfficeViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            if (!string.IsNullOrEmpty(SalesOfficeId))
            {
                var guid = Guid.Parse(SalesOfficeId);
                var salesoffice = await _viewModel.GetSalesOfficeByIdAsync(guid);
                _viewModel.Initialize(salesoffice, true);
            }
            else
            {
                _viewModel.Initialize(new SalesOfficeDTO(), false);
            }
        }
    }
}