using MirageMUD_ClientWPF.View;
using System.Windows;

namespace MirageMUD_ClientWPF
{
    // The main entry point of the application, inheriting from Application.
    public partial class App : Application
    {
        // Static properties to hold the positions of the main window.
        public static double LastLeft { get; set; } = double.NaN; // Left position of the window

        public static double LastTop { get; set; } = double.NaN; // Top position of the window

        // Static instances of each view that will be used across the application.
        public static LoginView LoginViewInstance { get; private set; }

        public static SettingsView SettingsViewInstance { get; private set; }
        public static CharactersView CharsViewInstance { get; private set; }
        public static NewCharView NewCharViewInstance { get; private set; }
        public static NewAccountView NewAccViewInstance { get; private set; }
        public static GameView GameViewInstance { get; private set; }

        // Overriding the OnStartup method to initialize the application's main views.
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize the shared view instances for later access.
            LoginViewInstance = new LoginView();
            SettingsViewInstance = new SettingsView();
            CharsViewInstance = new CharactersView();
            NewCharViewInstance = new NewCharView();
            NewAccViewInstance = new NewAccountView();
            GameViewInstance = new GameView();
        }
    }
}