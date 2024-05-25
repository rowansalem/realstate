

using RealStatesApp.Models;
using RealStatesApp.Pages.Owners;
using RealStatesApp.Services.Owner.Contracts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RealStatesApp.ViewModels
{
    public class OwnersListViewModel : INotifyPropertyChanged
    {
        // Properties
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IOwnersService _ownerService;
        private List<OwnerDTO> _ownersList;
        public ObservableCollection<OwnerDTO> Owners { get; } = new();
        public List<OwnerDTO> OwnersList
        {
            get => _ownersList;
            set
            {
                _ownersList = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AddCommand { get; }

        // Default constructor
        public OwnersListViewModel() : this(new DefaultOwnersService())
        {
        }

        // Constructor with dependency injection
        public OwnersListViewModel(IOwnersService ownerService)
        {
            _ownerService = ownerService;
            EditCommand = new Command<OwnerDTO>(OnEdit);
            DeleteCommand = new Command<OwnerDTO>(OnDelete);
            AddCommand = new Command(OnAdd);

            LoadOwners();
        }

        // Methods
        private async void LoadOwners()
        {
            OwnersList = await _ownerService.GetOwnersAsync();
            Owners.Clear();
            foreach (var owner in OwnersList)
            {
                Owners.Add(owner);
            }
        }

        public async Task LoadOwnersAsync()
        {
            LoadOwners();
        }

        private async void OnEdit(OwnerDTO owner)
        {
            var queryParameters = new Dictionary<string, object>
            {
            { "ownerId", owner.Id.ToString() } 
            };
            await Shell.Current.GoToAsync(nameof(AddEditOwnerPage), queryParameters);
        }


        private async void OnDelete(OwnerDTO owner)
        {
            await _ownerService.DeleteOwnerAsync(owner.Id);
            await LoadOwnersAsync();
        }

        private async void OnAdd()
        {
            await Shell.Current.GoToAsync(nameof(AddEditOwnerPage));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Default implementation of IOwnersService for the default constructor
    public class DefaultOwnersService : IOwnersService
    {
        public Task<List<OwnerDTO>> GetOwnersAsync()
        {
            return Task.FromResult(new List<OwnerDTO>());
        }

        public Task<OwnerDTO?> GetOwnerByIdAsync(Guid id)
        {
            return Task.FromResult<OwnerDTO?>(null);
        }

        public Task<bool?> CreateOwnerAsync(OwnerDTO owner)
        {
            return Task.FromResult<bool?>(true);
        }

        public Task<bool?> UpdateOwnerAsync(OwnerDTO owner)
        {
            return Task.FromResult<bool?>(true);
        }

        public Task<bool?> DeleteOwnerAsync(Guid id)
        {
            return Task.FromResult<bool?>(true);
        }
    }
}
