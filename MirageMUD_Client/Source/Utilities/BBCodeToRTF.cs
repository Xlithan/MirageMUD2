using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MirageMUD_Client.Source.Utilities
{
    public class BBCodeToRTF
    {
        private const string RTFHeader = @"{\rtf1\ansi";
        private List<string> colorTable = new List<string>();

        // Renamed Convert method to ConvertToRTF
        public string ConvertToRTF(string bbCode)
        {
            string rtfContent = bbCode;

            // Convert BBCode tags to RTF
            // Bold
            rtfContent = Regex.Replace(rtfContent, @"\[b\](.*?)\[/b\]", @"\b $1\b0");

            // Italic
            rtfContent = Regex.Replace(rtfContent, @"\[i\](.*?)\[/i\]", @"\i $1\i0");

            // Underline
            rtfContent = Regex.Replace(rtfContent, @"\[u\](.*?)\[/u\]", @"\ul $1\ul0");

            // Hex Color
            rtfContent = Regex.Replace(rtfContent, @"\[color=#([A-Fa-f0-9]{6})\](.*?)\[/color\]", match =>
            {
                string hexColor = match.Groups[1].Value;
                string text = match.Groups[2].Value;

                try
                {
                    // Parse the hex color to RGB
                    var (r, g, b) = ParseHexColor(hexColor);

                    // Add to color table
                    string colorDefinition = $@"\red{r}\green{g}\blue{b};";
                    if (!colorTable.Contains(colorDefinition))
                    {
                        colorTable.Add(colorDefinition);
                    }

                    // Get the color index
                    int colorIndex = colorTable.IndexOf(colorDefinition) + 1;

                    return $@"\cf{colorIndex} {text}\cf0";
                }
                catch (ArgumentException ex)
                {
                    // Handle invalid hex color gracefully
                    Console.WriteLine(ex.Message);
                    return text; // Fallback: return plain text without color
                }
            });

            // Build the RTF color table
            string rtfColorTable = BuildColorTable();

            return $"{RTFHeader}{rtfColorTable} {rtfContent} }}";
        }

        private string BuildColorTable()
        {
            if (colorTable.Count == 0)
                return string.Empty;

            return "{\\colortbl ;" + string.Join("", colorTable) + "}";
        }

        public (int r, int g, int b) ParseHexColor(string hexColor)
        {
            // Remove the '#' if present
            if (hexColor.StartsWith("#"))
            {
                hexColor = hexColor.Substring(1);
            }

            // Validate input
            if (string.IsNullOrEmpty(hexColor))
            {
                throw new ArgumentException("Hex color cannot be null or empty.");
            }

            if (hexColor.Length != 6 || !Regex.IsMatch(hexColor, "^[0-9A-Fa-f]{6}$"))
            {
                throw new ArgumentException($"Invalid hex color format: {hexColor}. Must be in RRGGBB format.");
            }

            // Convert hex to RGB using System.Convert
            int r = Convert.ToInt32(hexColor.Substring(0, 2), 16);
            int g = Convert.ToInt32(hexColor.Substring(2, 2), 16);
            int b = Convert.ToInt32(hexColor.Substring(4, 2), 16);

            return (r, g, b);
        }
    }
}