using MirageMUD_ClientWPF.View;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MirageMUD_ClientWPF
{
    public partial class App : Application
    {
        public static double LastLeft { get; set; } = double.NaN;
        public static double LastTop { get; set; } = double.NaN;
        public static LoginView LoginViewInstance { get; private set; }
        public static SettingsView SettingsViewInstance { get; private set; }
        public static CharactersView CharsViewInstance { get; private set; }
        public static NewCharView NewCharViewInstance { get; private set; }
        public static NewAccountView NewAccViewInstance { get; private set; }
        public static GameView GameViewInstance { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize the shared instances
            LoginViewInstance = new LoginView();
            SettingsViewInstance = new SettingsView();
            CharsViewInstance = new CharactersView();
            NewCharViewInstance = new NewCharView();
            NewAccViewInstance = new NewAccountView();
            GameViewInstance = new GameView();

        }
    }

}
