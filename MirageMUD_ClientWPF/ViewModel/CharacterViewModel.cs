using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MirageMUD_ClientWPF.ViewModel
{
    // ViewModel class for character data, implementing INotifyPropertyChanged for data binding.
    public class CharacterViewModel : INotifyPropertyChanged
    {
        // Character name
        public string Name { get; set; }

        // Path to the character's avatar image
        public string Avatar { get; set; }

        // Color of the character's name text
        public string NameColor { get; set; }

        // Character level
        public string Level { get; set; }

        // Character class information
        public string ClassInfo { get; set; }

        // Character race information
        public string RaceInfo { get; set; }

        // Character ID (used for identification)
        public int ID { get; set; }

        // Event for property changes, allowing UI to update when property values change.
        public event PropertyChangedEventHandler PropertyChanged;

        // Collection of character ViewModel objects, allowing for a list of characters to be displayed.
        private ObservableCollection<CharacterViewModel> _characters;

        // Property to get or set the list of characters.
        public ObservableCollection<CharacterViewModel> Characters
        {
            get => _characters;
            set
            {
                _characters = value;
                OnPropertyChanged(nameof(Characters)); // Notify UI about the change.
            }
        }

        // Constructor initializing the Characters collection as an ObservableCollection.
        public CharacterViewModel()
        {
            Characters = new ObservableCollection<CharacterViewModel>();
        }

        // Method to raise the PropertyChanged event, notifying the UI of changes to bound properties.
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}