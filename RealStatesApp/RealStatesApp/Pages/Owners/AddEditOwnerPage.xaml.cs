using RealStatesApp.Models;
using RealStatesApp.ViewModels;

namespace RealStatesApp.Pages.Owners
{
    [QueryProperty(nameof(OwnerId), "ownerId")]
    public partial class AddEditOwnerPage : ContentPage
    {
        private readonly AddEditOwnerViewModel _viewModel;
        public string OwnerId { get; set; }

        public AddEditOwnerPage(AddEditOwnerViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            if (!string.IsNullOrEmpty(OwnerId))
            {
                var guid = Guid.Parse(OwnerId);
                var owner = await _viewModel.GetOwnerByIdAsync(guid);
                _viewModel.Initialize(owner, true);
            }
            else
            {
                _viewModel.Initialize(new OwnerDTO(), false);
            }
        }
    }
}