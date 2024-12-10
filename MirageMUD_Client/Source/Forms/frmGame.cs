using MirageMUD_WFClient.Source.Utilities;
using System.Text.RegularExpressions;

namespace MirageMUD_WFClient
{
    public partial class frmGame : Form
    {
        public frmGame()
        {
            InitializeComponent(); // Initialize the form's components.
            txtInput.KeyDown += TxtInput_KeyDown; // Attach an event handler for the TextBox key press event.
        }

        // Handles the Enter key press in the input TextBox.
        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the default Enter behavior (e.g., ding sound).

                string inputText = txtInput.Text; // Retrieve the input text.

                // Strip BBCode-style tags (e.g., [b], [color]) from the text for sanitization.
                string sanitizedInputText = Regex.Replace(inputText, @"\[[^\]]*\]", "");

                // Create a formatted message with BBCode styling.
                string formattedMessage = "[color=#EE4B2B][b]Xlithan: [/color]" + sanitizedInputText;

                // Process the message and display it in the rich text box.
                BBCodeToRTF bbCodeProcessor = new BBCodeToRTF();
                bbCodeProcessor.ProcessTextAndColors(formattedMessage, rtbOutput);

                txtInput.Clear(); // Clear the input box after processing.
            }
        }

        // Event that fires when the form loads.
        private void frmGame_Load(object sender, EventArgs e)
        {
            // A welcome message showing how ASCII art can be used effectively.
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

            // Process and display each example message in the rich text box.
            foreach (string message in messages)
            {
                BBCodeToRTF bbCodeProcessor = new BBCodeToRTF();
                bbCodeProcessor.ProcessTextAndColors(message, rtbOutput);
            }
        }
    }
}