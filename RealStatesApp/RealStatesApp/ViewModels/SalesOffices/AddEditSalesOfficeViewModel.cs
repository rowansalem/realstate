using RealStatesApp.Models;
using RealStatesApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using RealStatesApp.Services.SalesOffice.Contracts;
using RealStatesApp.Services.SalesOffice.Contracts;

namespace RealStatesApp.ViewModels
{
    public class AddEditSalesOfficeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ISalesOfficeService _salesOfficeService;

        private SalesOfficeDTO _salesoffice;
        public SalesOfficeDTO SalesOffice
        {
            get => _salesoffice;
            set
            {
                _salesoffice = value;
                //if(value.SalesOfficeId != null)
                //{
                //    SelectedSalesOffice = SalesOffices.FirstOrDefault(x => x.Id == value.SalesOfficeId);
                //}

                OnPropertyChanged();
            }
        }

        private GetOfficeListResponse _selectedOffice;
        public ObservableCollection<GetOfficeListResponse> Offices { get; } = new();
        public GetOfficeListResponse SelectedOffice
        {
            get => _selectedOffice;
            set
            {
                if (_selectedOffice != value)
                {
                    _selectedOffice = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<SalesOfficeDTO> SalesOffices { get; } = new ObservableCollection<SalesOfficeDTO>();
        private SalesOfficeDTO _selectedSalesOffice;
        public SalesOfficeDTO SelectedSalesOffice
        {
            get => _selectedSalesOffice;
            set
            {
                _selectedSalesOffice = value;
                //SalesOffice.SalesOfficeId = value?.Id;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        private String _pageTitle;
        public String PageTitle
        {
            get => _pageTitle;
            set
            {
                _pageTitle = value;
                OnPropertyChanged();
            }
        }
        private String _buttonText;
        public string ButtonText
        {
            get => _buttonText;
            set
            {
                _buttonText = value;
                OnPropertyChanged();
            }
        }

        public AddEditSalesOfficeViewModel(ISalesOfficeService salesofficeService)
        {
            _salesOfficeService = salesofficeService;
            SaveCommand = new Command(OnSave);
            LoadSalesOffices();
        }

        public void Initialize(SalesOfficeDTO salesoffice, bool isEdit)
        {
            SalesOffice = salesoffice;
            PageTitle = isEdit ? "Edit SalesOffice" : "Add New SalesOffice";
            ButtonText = isEdit ? "Save Changes" : "Add SalesOffice";
            OnPropertyChanged();
        }

        private async void LoadSalesOffices()
        {
            var salesOffices = await _salesOfficeService.GetSalesOfficesListAsync();
            SalesOffices.Clear();
            foreach (var office in salesOffices)
            {
                SalesOffices.Add(office);
            }
        }

        private async void OnSave()
        {
            if (SalesOffice.Id == Guid.Empty)
            {
                await _salesOfficeService.CreateSalesOfficeAsync(SalesOffice);
            }
            else
            {
                await _salesOfficeService.UpdateSalesOfficeAsync(SalesOffice);
            }

            MessagingCenter.Send(this, "RefreshSalesOfficeList");

            await Shell.Current.GoToAsync("..");
        }

        public Task<SalesOfficeDTO> GetSalesOfficeByIdAsync(Guid salesofficeId)
        {
            return _salesOfficeService.GetSalesOfficeByIdAsync(salesofficeId);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
