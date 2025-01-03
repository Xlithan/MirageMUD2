using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace MirageMUD_ClientWPF.Model.Utilities
{
    internal class BBCodeToFD
    {
        // Method to process input text with BBCode and convert it into formatted text in a RichTextBox
        public void ProcessTextAndColors(string inputText, RichTextBox rtbOutput)
        {
            // Clear any existing content in the RichTextBox
            rtbOutput.Document.Blocks.Clear();

            // Regex pattern to match BBCode tags (bold, color, font)
            string combinedPattern = @"(\[b\]|\[/b\]|\[color=#([A-Fa-f0-9]{6})\]|\[/color\]|\[font=([^\]]+)\]|\[/font\])";
            // Find all matches of the BBCode tags in the input text
            MatchCollection matches = Regex.Matches(inputText, combinedPattern);

            // Create a new Paragraph to hold the processed text
            Paragraph paragraph = new Paragraph();
            rtbOutput.Document.Blocks.Add(paragraph);

            // Initialize the current index and default styles
            int currentIndex = 0;
            bool isBold = false; // Default text is not bold
            Brush currentColor = Brushes.Black; // Default text color is black
            string currentFont = "Segoe UI"; // Default font is Segoe UI

            // Iterate through each match (BBCode tag) in the input text
            foreach (Match match in matches)
            {
                // Add untagged text before the current match
                if (match.Index > currentIndex)
                {
                    string untaggedText = inputText.Substring(currentIndex, match.Index - currentIndex);
                    AddRun(paragraph, untaggedText, isBold, currentColor, currentFont);
                }

                // Process the current tag and update the corresponding style
                string tag = match.Value;
                if (tag == "[b]") // Bold tag
                {
                    isBold = true;
                }
                else if (tag == "[/b]") // End bold tag
                {
                    isBold = false;
                }
                else if (tag.StartsWith("[color=#")) // Color tag
                {
                    string colorHex = match.Groups[2].Value;
                    currentColor = (Brush)new BrushConverter().ConvertFrom($"#{colorHex}"); // Convert hex color to Brush
                }
                else if (tag == "[/color]") // End color tag
                {
                    currentColor = Brushes.Black; // Reset to default color (black)
                }
                else if (tag.StartsWith("[font=")) // Font tag
                {
                    currentFont = match.Groups[3].Value; // Set the font to the specified value
                }
                else if (tag == "[/font]") // End font tag
                {
                    currentFont = "Segoe UI"; // Reset to default font (Segoe UI)
                }

                // Update the current index to the end of the processed tag
                currentIndex = match.Index + match.Length;
            }

            // Append any remaining text after the last tag
            if (currentIndex < inputText.Length)
            {
                string remainingText = inputText.Substring(currentIndex);
                AddRun(paragraph, remainingText, isBold, currentColor, currentFont);
            }
        }

        // Helper method to add formatted text (Run) to the paragraph
        private void AddRun(Paragraph paragraph, string text, bool isBold, Brush color, string fontFamily)
        {
            // Create a new Run with the specified text and formatting options
            Run run = new Run(text)
            {
                Foreground = color, // Set the text color
                FontWeight = isBold ? FontWeights.Bold : FontWeights.Normal, // Set font weight to bold or normal
                FontFamily = new FontFamily(fontFamily) // Set the font family
            };
            // Add the Run to the Paragraph
            paragraph.Inlines.Add(run);
        }
    }
}