using System.Collections.ObjectModel;

namespace MirageMUD_ClientWPF.ViewModel
{
    // ViewModel class for managing the game's characters.
    public class GameViewModel
    {
        // ObservableCollection to hold a list of CharacterViewModel instances.
        public ObservableCollection<CharacterViewModel> Characters { get; set; }

        // Constructor initializing the Characters collection with sample data.
        public GameViewModel()
        {
            // Populate the Characters collection with sample data for testing or initial setup.
            Characters = new ObservableCollection<CharacterViewModel>
            {
                // Adding a sample character with attributes like Name, Avatar, and NameColor.
                new CharacterViewModel { Name = "Kubrick", Avatar = "gfx/avatars/Players/Male/5.bmp", NameColor = "LightGreen" },

                // Adding another sample character with different attributes.
                new CharacterViewModel { Name = "Xlithan", Avatar = "gfx/avatars/Players/Male/3.bmp", NameColor = "LightBlue" }
            };
        }
    }
}