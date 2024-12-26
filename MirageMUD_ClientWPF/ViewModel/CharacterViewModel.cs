using System.ComponentModel;

namespace MirageMUD_ClientWPF.ViewModel
{
    public class CharacterViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; } // Character name
        public string Avatar { get; set; } // Path to the avatar image
        public string NameColor { get; set; } // Color of the name

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
