using RealStatesApp.Models;
using System.ComponentModel;
using System.Net;

namespace RealStatesApp.Models
{
    public class OwnerDTO : BaseDTO
    {
        public string? OwnerFirstName { get; set; }
        public string? OwnerLastName { get; set; }
        public IEnumerable<Guid>? PropertiesId { get; set; }
        public List<PropertyDTO>? Properties { get; set; }  
        public DateTime Timestamp { get; set; }
        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }
    }


}
