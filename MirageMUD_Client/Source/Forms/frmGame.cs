using MirageMUD_Client.Source.Utilities;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using System.Diagnostics;

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
                string formattedMessage = "[color=#EE4B2B]Xlithan: [/color]" + inputText;

                // Process the input text and apply colors
                ProcessTextAndColors(formattedMessage);

                // Clear the TextBox after processing
                txtInput.Clear();
            }
        }

        // Method to process input text and apply colors
        private void ProcessTextAndColors(string inputText)
        {
            // Regex to match font, bold, and color tags
            string fontPattern = @"\[font=([^\]]+)\]";
            string boldPattern = @"\[b\]";
            string boldClosePattern = @"\[/b\]";
            string fontClosePattern = @"\[/font\]";
            string colorPattern = @"\[color=#([A-Fa-f0-9]{6})\](.*?)\[/color\]";

            string resultText = inputText;

            // Process font tags
            if (Regex.IsMatch(resultText, fontPattern))
            {
                Match fontMatch = Regex.Match(resultText, fontPattern);
                string fontName = fontMatch.Groups[1].Value;
                rtbOutput.SelectionFont = new System.Drawing.Font(fontName, rtbOutput.Font.Size);
                resultText = resultText.Replace(fontMatch.Value, "").Replace("[/font]", ""); // Remove both opening and closing font tags
            }

            // Process bold tags
            if (Regex.IsMatch(resultText, boldPattern))
            {
                rtbOutput.SelectionFont = new System.Drawing.Font(rtbOutput.SelectionFont, FontStyle.Bold);
                resultText = resultText.Replace("[b]", "").Replace("[/b]", ""); // Remove bold tags
            }

            // Process color tags
            MatchCollection matches = Regex.Matches(resultText, colorPattern);
            int currentIndex = 0; // Keeps track of the position in the input text

            foreach (Match match in matches)
            {
                // Append untagged text before the current match
                if (match.Index > currentIndex)
                {
                    string untaggedText = resultText.Substring(currentIndex, match.Index - currentIndex);
                    rtbOutput.SelectionColor = Color.White; // Default color
                    rtbOutput.AppendText(untaggedText);
                }

                // Extract and process the color and text inside the tag
                string colorHex = match.Groups[1].Value;
                string coloredText = match.Groups[2].Value;

                // Convert hex color to RGB values
                var (r, g, b) = ParseHexColor(colorHex);

                // Apply the color and append the text
                rtbOutput.SelectionColor = Color.FromArgb(r, g, b);
                rtbOutput.AppendText(coloredText);

                // Update the current index to after the current match
                currentIndex = match.Index + match.Length;
            }

            // Append any remaining untagged text at the end
            if (currentIndex < resultText.Length)
            {
                string remainingText = resultText.Substring(currentIndex);
                rtbOutput.SelectionColor = Color.White; // Default color
                rtbOutput.SelectionFont = new System.Drawing.Font(rtbOutput.SelectionFont, FontStyle.Regular); // Revert to regular font style
                rtbOutput.AppendText(remainingText);
            }

            // Add a newline at the end of each message
            rtbOutput.AppendText(Environment.NewLine);
        }

        // Helper function to parse hex color code into RGB values
        private (int r, int g, int b) ParseHexColor(string hex)
        {
            int r = Convert.ToInt32(hex.Substring(0, 2), 16);
            int g = Convert.ToInt32(hex.Substring(2, 2), 16);
            int b = Convert.ToInt32(hex.Substring(4, 2), 16);
            return (r, g, b);
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

                "[color=#d62424][b]There are no other[/b] players online.[/color]",
                "[color=#FFFF00]<< [/color][color=#FFFFFF]Ebersmile Tavern [/color][color=#FFFF00]>>[/color]",
                "[color=#8888FF]You are in the Ebersmile Tavern, your average drinking house.[/color]",
                "[color=#8888FF]The tavern exits to the [/color][color=#66FF00]East[/color][color=#8888FF].[/color]"
            };

            // Iterate over each message and process it through ProcessTextAndColors
            foreach (string message in messages)
            {
                // Process each message and append to the RichTextBox
                ProcessTextAndColors(message);
            }
        }
    }
}
