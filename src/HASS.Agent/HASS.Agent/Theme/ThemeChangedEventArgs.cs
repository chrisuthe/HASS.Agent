using System;

namespace HASS.Agent.Theme
{
    /// <summary>
    /// Event arguments for theme change notifications
    /// </summary>
    public class ThemeChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The new theme that has been applied
        /// </summary>
        public AppTheme NewTheme { get; }

        /// <summary>
        /// The previous theme before the change
        /// </summary>
        public AppTheme? OldTheme { get; }

        public ThemeChangedEventArgs(AppTheme newTheme, AppTheme? oldTheme = null)
        {
            NewTheme = newTheme;
            OldTheme = oldTheme;
        }
    }
}
