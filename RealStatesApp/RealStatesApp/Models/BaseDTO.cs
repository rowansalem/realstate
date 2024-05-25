using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RealStatesApp.Models
{
    public class BaseDTO: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public Guid Id { get; set; }

    }
}