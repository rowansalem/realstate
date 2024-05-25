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
using RealStatesApp.Services.Employee.Contracts;
using RealStatesApp.Services.Owner.Contracts;

namespace RealStatesApp.ViewModels
{
    public class AddEditOwnerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IOwnersService _ownerService;
        private readonly ISalesOfficeService _salesOfficeService;

        private OwnerDTO _owner;
        public OwnerDTO Owner
        {
            get => _owner;
            set
            {
                _owner = value;

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

        public AddEditOwnerViewModel(IOwnersService ownerService, ISalesOfficeService salesOfficeService)
        {
            _ownerService = ownerService;
            _salesOfficeService = salesOfficeService;
            SaveCommand = new Command(OnSave);
        }

        public void Initialize(OwnerDTO owner, bool isEdit)
        {
            Owner = owner;
            PageTitle = isEdit ? "Edit Owner" : "Add New Owner";
            ButtonText = isEdit ? "Save Changes" : "Add Owner";
            OnPropertyChanged();
        }

        private async void OnSave()
        {
            if (Owner.Id == Guid.Empty)
            {
                await _ownerService.CreateOwnerAsync(Owner);
            }
            else
            {
                await _ownerService.UpdateOwnerAsync(Owner);
            }

            MessagingCenter.Send(this, "RefreshOwnerList");

            await Shell.Current.GoToAsync("..");
        }

        public Task<OwnerDTO> GetOwnerByIdAsync(Guid ownerId)
        {
            return _ownerService.GetOwnerByIdAsync(ownerId);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
