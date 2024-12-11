namespace MirageMUD_Client.Source.Utilities
{
    internal class RadioButtonManager
    {
        private RadioButton[] _radioButtons;

        public RadioButtonManager(Panel panel)
        {
            // Initialize the array with radio buttons from the panel
            _radioButtons = panel.Controls.OfType<RadioButton>().ToArray();

            // Subscribe to the CheckedChanged event for all buttons
            foreach (var radioButton in _radioButtons)
            {
                radioButton.CheckedChanged += RadioButton_CheckedChanged;
            }
        }

        public RadioButton[] RadioButtons => _radioButtons;

        // Method to enable or disable specific radio buttons
        public void SetEnabled(string[] buttonTexts, bool enabled)
        {
            foreach (var radioButton in _radioButtons)
            {
                if (buttonTexts.Contains(radioButton.Text))
                {
                    radioButton.Enabled = enabled;
                }
            }
        }

        // Example event handler (optional, can be customized per need)
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.Checked)
            {
                Console.WriteLine($"Selected: {radioButton.Text}");
            }
        }
    }
}
