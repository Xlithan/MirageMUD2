using System.Collections.ObjectModel;

namespace MirageMUD_ClientWPF.ViewModel
{
    public class GameViewModel
    {
        public ObservableCollection<CharacterViewModel> Characters { get; set; }

        public GameViewModel()
        {
            // Populate with sample data
            Characters = new ObservableCollection<CharacterViewModel>
            {
                new CharacterViewModel { Name = "Kubrick", Avatar = "gfx/avatars/Players/Male/5.bmp", NameColor = "LightGreen" },
                new CharacterViewModel { Name = "Xlithan", Avatar = "gfx/avatars/Players/Male/3.bmp", NameColor = "LightBlue" }
            };
        }
    }
}
