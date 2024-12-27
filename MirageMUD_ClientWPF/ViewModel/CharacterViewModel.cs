using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MirageMUD_ClientWPF.ViewModel
{
    public class CharacterViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; } // Character name
        public string Avatar { get; set; } // Path to the avatar image
        public string NameColor { get; set; } // Color of the name
        public string Level { get; set; } // Character level
        public string ClassInfo { get; set; } // Character class

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<CharacterViewModel> _characters;

        public ObservableCollection<CharacterViewModel> Characters
        {
            get => _characters;
            set
            {
                _characters = value;
                OnPropertyChanged(nameof(Characters));
            }
        }
        public CharacterViewModel()
        {
            Characters = new ObservableCollection<CharacterViewModel>();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
