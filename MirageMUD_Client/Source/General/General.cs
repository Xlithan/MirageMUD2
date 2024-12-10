﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using MirageMUD_WFClient.Source.Network;

namespace MirageMUD_WFClient.Source.General
{
    internal class General
    {
        // The object that will handle all data. Readonly because we dont want this to change, we want a single instance.
        private readonly CHandleData _cHandleData;

        // Constructor for the General class.
        // Creates a new SHandleData internally and calls InitialiseMessages on it.
        public General()
        {
            _cHandleData = new CHandleData();
            _cHandleData.InitialiseMessages();
        }

        public void Main()
        {
            // Start the application
            Application.Run(new frmMenu());
        }

        // This method updates the text of controls on the given form, including controls within group boxes
        public static void UpdateControlText(Form form)
        {
            // Call the recursive method to update all controls, including nested ones
            UpdateControlTextRecursively(form);
        }

        // Recursive method to update text for all controls in the form and nested containers
        private static void UpdateControlTextRecursively(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                // Build the translation key for this control
                string translationKey = $"controls.{control.Name}.text";

                // Get the translation from the TranslationManager
                string translatedText = TranslationManager.Instance.GetTranslation(translationKey);

                // Only update the control text if a translation is found
                if (translatedText != translationKey)  // Translation found, not using the key itself
                {
                    // Handle Button controls
                    if (control is Button button)
                    {
                        button.Text = translatedText;
                    }
                    // Handle Label controls
                    else if (control is Label label)
                    {
                        label.Text = translatedText;
                    }
                    // Handle CheckBox controls
                    else if (control is CheckBox checkBox)
                    {
                        checkBox.Text = translatedText;
                    }
                }

                // Recursively update child controls in containers (group boxes, panels, etc.)
                if (control.Controls.Count > 0)
                {
                    UpdateControlTextRecursively(control);
                }
            }
        }
    }
}
