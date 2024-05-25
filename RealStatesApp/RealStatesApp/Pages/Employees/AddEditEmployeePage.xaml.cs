using RealStatesApp.Models;
using RealStatesApp.ViewModels;

namespace RealStatesApp.Pages.Employees
{
    [QueryProperty(nameof(EmployeeId), "employeeId")]
    public partial class AddEditEmployeePage : ContentPage
    {
        private readonly AddEditEmployeeViewModel _viewModel;
        public string EmployeeId { get; set; }

        public AddEditEmployeePage(AddEditEmployeeViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            if (!string.IsNullOrEmpty(EmployeeId))
            {
                var guid = Guid.Parse(EmployeeId);
                var employee = await _viewModel.GetEmployeeByIdAsync(guid);
                _viewModel.Initialize(employee, true);
            }
            else
            {
                _viewModel.Initialize(new EmployeeDTO(), false);
            }
        }
    }
}