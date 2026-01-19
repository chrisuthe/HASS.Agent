using System;
using System.Windows.Forms;
using HASS.Agent.Theme;

namespace HASS.Agent.Controls
{
    /// <summary>
    /// Base UserControl class that automatically subscribes to theme changes
    /// and applies the current theme when loaded or when the theme changes.
    /// </summary>
    public class ThemeAwareUserControl : UserControl
    {
        private bool _themeSubscribed;

        public ThemeAwareUserControl()
        {
            // Subscribe to theme changes
            ThemeManager.ThemeChanged += OnThemeChanged;
            _themeSubscribed = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Apply theme when control loads
            ApplyTheme();
        }

        /// <summary>
        /// Apply the current theme to this control and all its children.
        /// Override this method to add custom theme logic for specific controls.
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
                    // Control was disposed, ignore
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
