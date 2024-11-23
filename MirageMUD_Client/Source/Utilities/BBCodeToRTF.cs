using System.Text.RegularExpressions;

namespace MirageMUD_Client.Source.Utilities
{
    public class BBCodeToRTF
    {
        // Method to process input text and apply colors
        public void ProcessTextAndColors(string inputText, RichTextBox rtbOutput)
        {
            // Regex to match all tags
            string combinedPattern = @"(\[b\]|\[/b\]|\[color=#([A-Fa-f0-9]{6})\]|\[/color\]|\[font=([^\]]+)\]|\[/font\])";
            MatchCollection matches = Regex.Matches(inputText, combinedPattern);

            int currentIndex = 0; // Tracks the current position in the input text
            bool isBold = false;
            Color currentColor = Color.White; // Default text color
            string currentFont = rtbOutput.Font.FontFamily.Name; // Default font family

            foreach (Match match in matches)
            {
                // Append text before the current tag
                if (match.Index > currentIndex)
                {
                    string untaggedText = inputText.Substring(currentIndex, match.Index - currentIndex);

                    // Apply the current formatting to the untagged text
                    rtbOutput.SelectionFont = new System.Drawing.Font(currentFont, rtbOutput.Font.Size, isBold ? FontStyle.Bold : FontStyle.Regular);
                    rtbOutput.SelectionColor = currentColor;
                    rtbOutput.AppendText(untaggedText);
                }

                // Process the current tag
                string tag = match.Value;
                if (tag == "[b]")
                {
                    isBold = true; // Enable bold
                }
                else if (tag == "[/b]")
                {
                    isBold = false; // Disable bold
                }
                else if (tag.StartsWith("[color=#"))
                {
                    string colorHex = match.Groups[2].Value; // Extract color hex
                    var (r, g, b) = ReParseHexColor(colorHex);
                    currentColor = Color.FromArgb(r, g, b);
                }
                else if (tag == "[/color]")
                {
                    currentColor = Color.White; // Revert to default color
                }
                else if (tag.StartsWith("[font="))
                {
                    currentFont = match.Groups[3].Value; // Extract font name
                }
                else if (tag == "[/font]")
                {
                    currentFont = rtbOutput.Font.FontFamily.Name; // Revert to default font
                }

                // Update the current index to after the current match
                currentIndex = match.Index + match.Length;
            }

            // Append any remaining text after the last tag
            if (currentIndex < inputText.Length)
            {
                string remainingText = inputText.Substring(currentIndex);
                rtbOutput.SelectionFont = new System.Drawing.Font(currentFont, rtbOutput.Font.Size, isBold ? FontStyle.Bold : FontStyle.Regular);
                rtbOutput.SelectionColor = currentColor;
                rtbOutput.AppendText(remainingText);
            }

            // Add a newline at the end of the message
            rtbOutput.AppendText(Environment.NewLine);
        }

        // Helper function to parse hex color code into RGB values
        private (int r, int g, int b) ReParseHexColor(string hex)
        {
            int r = Convert.ToInt32(hex.Substring(0, 2), 16);
            int g = Convert.ToInt32(hex.Substring(2, 2), 16);
            int b = Convert.ToInt32(hex.Substring(4, 2), 16);
            return (r, g, b);
        }
    }
}