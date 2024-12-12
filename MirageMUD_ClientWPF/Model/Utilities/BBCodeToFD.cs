using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace MirageMUD_ClientWPF.Model.Utilities
{
    internal class BBCodeToFD
    {
        public void ProcessTextAndColors(string inputText, RichTextBox rtbOutput)
        {
            // Clear existing content
            rtbOutput.Document.Blocks.Clear();

            // Regex to match all tags
            string combinedPattern = @"(\[b\]|\[/b\]|\[color=#([A-Fa-f0-9]{6})\]|\[/color\]|\[font=([^\]]+)\]|\[/font\])";
            MatchCollection matches = Regex.Matches(inputText, combinedPattern);

            Paragraph paragraph = new Paragraph();
            rtbOutput.Document.Blocks.Add(paragraph);

            int currentIndex = 0;
            bool isBold = false;
            Brush currentColor = Brushes.Black; // Default text color
            string currentFont = "Segoe UI"; // Default font

            foreach (Match match in matches)
            {
                // Append untagged text
                if (match.Index > currentIndex)
                {
                    string untaggedText = inputText.Substring(currentIndex, match.Index - currentIndex);
                    AddRun(paragraph, untaggedText, isBold, currentColor, currentFont);
                }

                // Process tags
                string tag = match.Value;
                if (tag == "[b]")
                {
                    isBold = true;
                }
                else if (tag == "[/b]")
                {
                    isBold = false;
                }
                else if (tag.StartsWith("[color=#"))
                {
                    string colorHex = match.Groups[2].Value;
                    currentColor = (Brush)new BrushConverter().ConvertFrom($"#{colorHex}");
                }
                else if (tag == "[/color]")
                {
                    currentColor = Brushes.Black; // Default text color
                }
                else if (tag.StartsWith("[font="))
                {
                    currentFont = match.Groups[3].Value;
                }
                else if (tag == "[/font]")
                {
                    currentFont = "Segoe UI"; // Default font
                }

                // Update the current index
                currentIndex = match.Index + match.Length;
            }

            // Append remaining text
            if (currentIndex < inputText.Length)
            {
                string remainingText = inputText.Substring(currentIndex);
                AddRun(paragraph, remainingText, isBold, currentColor, currentFont);
            }
        }

        private void AddRun(Paragraph paragraph, string text, bool isBold, Brush color, string fontFamily)
        {
            Run run = new Run(text)
            {
                Foreground = color,
                FontWeight = isBold ? FontWeights.Bold : FontWeights.Normal,
                FontFamily = new FontFamily(fontFamily)
            };
            paragraph.Inlines.Add(run);
        }
    }
}
