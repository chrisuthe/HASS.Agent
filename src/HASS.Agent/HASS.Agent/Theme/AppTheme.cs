using System.Drawing;

namespace HASS.Agent.Theme
{
    /// <summary>
    /// Defines a complete color scheme for the application
    /// </summary>
    public class AppTheme
    {
        /// <summary>
        /// Theme name for identification
        /// </summary>
        public string Name { get; init; } = string.Empty;

        // Form and panel backgrounds
        public Color FormBackground { get; init; }
        public Color ControlBackground { get; init; }
        public Color MenuBackground { get; init; }

        // Text colors
        public Color ForeColor { get; init; }
        public Color DisabledForeColor { get; init; }

        // Border colors
        public Color BorderColor { get; init; }
        public Color FocusBorderColor { get; init; }

        // Interactive state colors
        public Color HoverColor { get; init; }
        public Color PressedColor { get; init; }
        public Color DisabledBackColor { get; init; }

        // Selection colors
        public Color SelectedBackground { get; init; }
        public Color SelectedForeColor { get; init; }

        // Accent color (used for focus indicators, active states)
        public Color AccentColor { get; init; }

        // Separator/divider color
        public Color SeparatorColor { get; init; }

        /// <summary>
        /// Dark theme - the current/original HASS.Agent theme
        /// </summary>
        public static AppTheme Dark { get; } = new()
        {
            Name = "Dark",

            // Backgrounds
            FormBackground = Color.FromArgb(45, 45, 48),      // #2D2D30
            ControlBackground = Color.FromArgb(63, 63, 70),   // #3F3F46
            MenuBackground = Color.FromArgb(37, 37, 38),      // #252526

            // Text
            ForeColor = Color.FromArgb(241, 241, 241),        // #F1F1F1
            DisabledForeColor = Color.FromArgb(120, 120, 120), // #787878

            // Borders
            BorderColor = Color.FromArgb(70, 70, 70),         // #464646
            FocusBorderColor = Color.FromArgb(0, 122, 204),   // #007ACC

            // Interactive states
            HoverColor = Color.FromArgb(78, 78, 86),          // #4E4E56
            PressedColor = Color.FromArgb(55, 55, 60),        // #37373C
            DisabledBackColor = Color.FromArgb(50, 50, 53),   // #323235

            // Selection
            SelectedBackground = Color.FromArgb(241, 241, 241), // #F1F1F1 (inverted)
            SelectedForeColor = Color.FromArgb(63, 63, 70),    // #3F3F46 (inverted)

            // Accent
            AccentColor = Color.FromArgb(0, 122, 204),        // #007ACC

            // Separator
            SeparatorColor = Color.FromArgb(70, 70, 70)       // #464646
        };

        /// <summary>
        /// Light theme - Windows 11 inspired light colors
        /// </summary>
        public static AppTheme Light { get; } = new()
        {
            Name = "Light",

            // Backgrounds
            FormBackground = Color.FromArgb(249, 249, 249),   // #F9F9F9
            ControlBackground = Color.FromArgb(255, 255, 255), // #FFFFFF
            MenuBackground = Color.FromArgb(243, 243, 243),   // #F3F3F3

            // Text
            ForeColor = Color.FromArgb(32, 32, 32),           // #202020
            DisabledForeColor = Color.FromArgb(160, 160, 160), // #A0A0A0

            // Borders
            BorderColor = Color.FromArgb(200, 200, 200),      // #C8C8C8
            FocusBorderColor = Color.FromArgb(0, 120, 212),   // #0078D4

            // Interactive states
            HoverColor = Color.FromArgb(229, 229, 229),       // #E5E5E5
            PressedColor = Color.FromArgb(204, 204, 204),     // #CCCCCC
            DisabledBackColor = Color.FromArgb(240, 240, 240), // #F0F0F0

            // Selection
            SelectedBackground = Color.FromArgb(0, 120, 212),  // #0078D4
            SelectedForeColor = Color.FromArgb(255, 255, 255), // #FFFFFF

            // Accent
            AccentColor = Color.FromArgb(0, 120, 212),        // #0078D4

            // Separator
            SeparatorColor = Color.FromArgb(225, 225, 225)    // #E1E1E1
        };
    }
}
