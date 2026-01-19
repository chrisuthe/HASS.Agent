using System;
using System.Windows.Forms;
using HASS.Agent.Theme;

namespace HASS.Agent.Forms
{
    /// <summary>
    /// Base form class that automatically subscribes to theme changes
    /// and applies the current theme when loaded or when the theme changes.
    /// </summary>
    public class ThemeAwareForm : Form
    {
        private bool _themeSubscribed;

        public ThemeAwareForm()
        {
            // Subscribe to theme changes
            ThemeManager.ThemeChanged += OnThemeChanged;
            _themeSubscribed = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Apply theme when form loads
            ApplyTheme();
        }

        /// <summary>
        /// Apply the current theme to this form and all its controls.
        /// Override this method to add custom theme logic for specific forms.
        /// </summary>
        protected virtual void ApplyTheme()
        {
            ThemeManager.ApplyTheme(this);
        }

        private void OnThemeChanged(object? sender, ThemeChangedEventArgs e)
        {
            // Handle cross-thread invocation
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new Action(ApplyTheme));
                }
                catch (ObjectDisposedException)
                {
                    // Form was disposed, ignore
                }
            }
            else
            {
                ApplyTheme();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _themeSubscribed)
            {
                ThemeManager.ThemeChanged -= OnThemeChanged;
                _themeSubscribed = false;
            }

            base.Dispose(disposing);
        }
    }
}
