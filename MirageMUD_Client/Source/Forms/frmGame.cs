using MirageMUD_Client.Source.Utilities;

namespace MirageMUD_Client
{
    public partial class frmGame : Form
    {
        public frmGame()
        {
            InitializeComponent();
            txtInput.KeyDown += TxtInput_KeyDown;
        }

        // Event handler for TxtInput_KeyDown
        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the ding sound and default behavior

                // Get the text from the TextBox
                string inputText = txtInput.Text;

                // Build the formatted message to display
                string formattedMessage = "[color=#EE4B2B][b]Xlithan: [/color]" + inputText;

                // Process the input text and apply colors
                BBCodeToRTF bbCodeProcessor = new BBCodeToRTF();
                bbCodeProcessor.ProcessTextAndColors(formattedMessage, rtbOutput);

                // Clear the TextBox after processing
                txtInput.Clear();
            }
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            // Example messages
            string[] messages =
            {
                "[font=Courier New][b][color=#964B00]                                                |[/color][color=#FFFF00]>>>[/color][/b][/font]",
                "[font=Courier New][b][color=#964B00]                                                |[/color][/b][/font]",
                "[font=Courier New][b][color=#808080]                                            _  _[/color][color=#964B00]|[/color][color=#808080]_ _[/color][/b][/font]",
                "[font=Courier New][b][color=#0096FF]___  ____                                 [/color][color=#808080] |;|_|;|_|;|[/color][/b][/font]",
                "[font=Courier New][b][color=#0096FF]|  \\/  (_)                                [/color][color=#808080] \\\\.    .  /[/color][/b][/font]",
                "[font=Courier New][b][color=#0096FF]| .  . |_ _ __ __ _  __ _  ___            [/color][color=#808080]  \\\\:  .  /[/color][/b][/font]",
                "[font=Courier New][b][color=#0096FF]| |\\/| | | '__/ _` |/ _` |/ _ \\           [/color][color=#808080]   ||:   |[/color][/b][/font]",
                "[font=Courier New][b][color=#0096FF]| |  | | | | | (_| | (_| |  __/           [/color][color=#808080]   ||:.  |[/color][/b][/font]",
                "[font=Courier New][b][color=#0096FF]\\_|  |_|_|_|  \\__,_|\\__, |\\___|           [/color][color=#808080]   ||:  .|[/color][/b][/font]",
                "[font=Courier New][b][color=#0096FF]___  ____   _______  __/ |                [/color][color=#808080]   ||:   |       [/color][color=#FFFFFF]\\,/[/color][/b][/font]",
                "[font=Courier New][b][color=#0096FF]|  \\/  | | | |  _  \\|___/                 [/color][color=#808080]   ||: , |            [/color][color=#FFFFFF]/`\\[/color][/b][/font]",
                "[font=Courier New][b][color=#0096FF]| .  . | | | | | | |                      [/color][color=#808080]   ||:   |[/color][/b][/font]",
                "[font=Courier New][b][color=#0096FF]| |\\/| | | | | | | |                      [/color][color=#808080]   ||: . |[/color][/b][/font]",
                "[font=Courier New][b][color=#0096FF]| |  | | |_| | |/ /                         [/color][color=#66ff00]_[/color][color=#808080]||[/color][color=#66ff00]_   [/color][color=#808080]|[/color][/b][/font]",
                "[font=Courier New][b][color=#0096FF]\\_|  |_/\\___/|___/[/color][color=#66ff00]--~~__            __ ----~    ~`---,[/color][/b][/font]",
                "[font=Courier New][b][color=#66ff00]-~--~                   ~---__ ,--~'                  ~~----_____[/color][/b][/font]",
                "[b][color=#2ec8f2]Welcome to the test client for MirageMUD.[/color][/b]",

                "[color=#d62424][b]There are no other players online.[/color]",
                "[color=#FFFF00][b]<< [/color][color=#FFFFFF]Ebersmile Tavern [/color][color=#FFFF00]>>[/color]",
                "[color=#8888FF][b]You are in the Ebersmile Tavern, your average drinking house.[/color]",
                "[color=#8888FF][b]The tavern exits to the [/color][color=#66FF00]East[/color][color=#8888FF].[/color]"
            };

            // Iterate over each message and process it through ProcessTextAndColors
            foreach (string message in messages)
            {
                // Process the input text and apply colors
                BBCodeToRTF bbCodeProcessor = new BBCodeToRTF();
                bbCodeProcessor.ProcessTextAndColors(message, rtbOutput);
            }
        }
    }
}
