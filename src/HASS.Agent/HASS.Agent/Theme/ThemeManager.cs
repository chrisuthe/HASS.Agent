using System;
using System.Drawing;
using System.Windows.Forms;
using HASS.Agent.Controls;
using HASS.Agent.Enums;
using Microsoft.Win32;
using Serilog;

namespace HASS.Agent.Theme
{
    /// <summary>
    /// Centralized theme management for the application.
    /// Handles Windows theme detection, theme switching, and applying themes to controls.
    /// </summary>
    public static class ThemeManager
    {
        private const string PersonalizationKey = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
        private const string AppsUseLightThemeValue = "AppsUseLightTheme";

        private static AppTheme _currentTheme = AppTheme.Dark;
        private static ThemeMode _themeMode = ThemeMode.System;
        private static bool _initialized;

        /// <summary>
        /// Event fired when the theme changes
        /// </summary>
        public static event EventHandler<ThemeChangedEventArgs>? ThemeChanged;

        /// <summary>
        /// The currently active theme
        /// </summary>
        public static AppTheme CurrentTheme => _currentTheme;

        /// <summary>
        /// How the theme is determined (System, Light, or Dark)
        /// </summary>
        public static ThemeMode ThemeMode
        {
            get => _themeMode;
            set
            {
                if (_themeMode == value) return;
                _themeMode = value;
                UpdateCurrentTheme();
            }
        }

        // Convenience properties for direct color access
        public static Color FormBackground => _currentTheme.FormBackground;
        public static Color ControlBackground => _currentTheme.ControlBackground;
        public static Color MenuBackground => _currentTheme.MenuBackground;
        public static Color ForeColor => _currentTheme.ForeColor;
        public static Color DisabledForeColor => _currentTheme.DisabledForeColor;
        public static Color BorderColor => _currentTheme.BorderColor;
        public static Color FocusBorderColor => _currentTheme.FocusBorderColor;
        public static Color HoverColor => _currentTheme.HoverColor;
        public static Color PressedColor => _currentTheme.PressedColor;
        public static Color DisabledBackColor => _currentTheme.DisabledBackColor;
        public static Color SelectedBackground => _currentTheme.SelectedBackground;
        public static Color SelectedForeColor => _currentTheme.SelectedForeColor;
        public static Color AccentColor => _currentTheme.AccentColor;
        public static Color SeparatorColor => _currentTheme.SeparatorColor;

        /// <summary>
        /// Initialize the theme manager. Call this before Application.Run().
        /// </summary>
        /// <param name="themeMode">Initial theme mode preference</param>
        public static void Initialize(ThemeMode themeMode = ThemeMode.System)
        {
            if (_initialized) return;

            _themeMode = themeMode;
            UpdateCurrentTheme();

            // Subscribe to Windows theme changes
            SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;

            _initialized = true;
            Log.Debug("[ThemeManager] Initialized with mode {Mode}, current theme: {Theme}",
                _themeMode, _currentTheme.Name);
        }

        /// <summary>
        /// Cleanup resources. Call this on application exit.
        /// </summary>
        public static void Shutdown()
        {
            SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
            _initialized = false;
        }

        /// <summary>
        /// Check if Windows is currently using light theme
        /// </summary>
        public static bool IsWindowsLightTheme()
        {
            try
            {
                using var key = Registry.CurrentUser.OpenSubKey(PersonalizationKey);
                var value = key?.GetValue(AppsUseLightThemeValue);
                return value is int intValue && intValue == 1;
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "[ThemeManager] Failed to detect Windows theme, defaulting to dark");
                return false;
            }
        }

        /// <summary>
        /// Apply the current theme to a control and all its children recursively
        /// </summary>
        public static void ApplyTheme(Control control)
        {
            if (control == null) return;

            ApplyThemeToControl(control);

            foreach (Control child in control.Controls)
            {
                ApplyTheme(child);
            }
        }

        /// <summary>
        /// Force a theme refresh on all subscribed forms
        /// </summary>
        public static void RefreshTheme()
        {
            ThemeChanged?.Invoke(null, new ThemeChangedEventArgs(_currentTheme));
        }

        private static void UpdateCurrentTheme()
        {
            var oldTheme = _currentTheme;

            _currentTheme = _themeMode switch
            {
                ThemeMode.Light => AppTheme.Light,
                ThemeMode.Dark => AppTheme.Dark,
                ThemeMode.System => IsWindowsLightTheme() ? AppTheme.Light : AppTheme.Dark,
                _ => AppTheme.Dark
            };

            if (oldTheme?.Name != _currentTheme.Name)
            {
                Log.Debug("[ThemeManager] Theme changed from {OldTheme} to {NewTheme}",
                    oldTheme?.Name ?? "none", _currentTheme.Name);
                ThemeChanged?.Invoke(null, new ThemeChangedEventArgs(_currentTheme, oldTheme));
            }
        }

        private static void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            // Windows theme changes are signaled through the General category
            if (e.Category != UserPreferenceCategory.General) return;

            // Only react if we're following the system theme
            if (_themeMode != ThemeMode.System) return;

            Log.Debug("[ThemeManager] Windows theme preference changed, updating...");
            UpdateCurrentTheme();
        }

        private static void ApplyThemeToControl(Control control)
        {
            switch (control)
            {
                case Form form:
                    form.BackColor = _currentTheme.FormBackground;
                    form.ForeColor = _currentTheme.ForeColor;
                    break;

                case ModernButton mb:
                    mb.BackColor = _currentTheme.ControlBackground;
                    mb.ForeColor = _currentTheme.ForeColor;
                    mb.HoverColor = _currentTheme.HoverColor;
                    mb.PressedColor = _currentTheme.PressedColor;
                    mb.FocusBorderColor = _currentTheme.FocusBorderColor;
                    break;

                case Button btn:
                    btn.BackColor = _currentTheme.ControlBackground;
                    btn.ForeColor = _currentTheme.ForeColor;
                    if (btn.FlatStyle == FlatStyle.Flat)
                    {
                        btn.FlatAppearance.BorderColor = _currentTheme.BorderColor;
                    }
                    break;

                case CustomGroupBox cgb:
                    cgb.BackColor = _currentTheme.FormBackground;
                    cgb.ForeColor = _currentTheme.ForeColor;
                    cgb.BorderColor = _currentTheme.BorderColor;
                    break;

                case GroupBox gb:
                    gb.BackColor = _currentTheme.FormBackground;
                    gb.ForeColor = _currentTheme.ForeColor;
                    break;

                case TextBox tb:
                    tb.BackColor = _currentTheme.ControlBackground;
                    tb.ForeColor = _currentTheme.ForeColor;
                    break;

                case RichTextBox rtb:
                    rtb.BackColor = _currentTheme.ControlBackground;
                    rtb.ForeColor = _currentTheme.ForeColor;
                    break;

                case ComboBox cb:
                    cb.BackColor = _currentTheme.ControlBackground;
                    cb.ForeColor = _currentTheme.ForeColor;
                    break;

                case ListBox lb:
                    lb.BackColor = _currentTheme.ControlBackground;
                    lb.ForeColor = _currentTheme.ForeColor;
                    break;

                case ListView lv:
                    lv.BackColor = _currentTheme.ControlBackground;
                    lv.ForeColor = _currentTheme.ForeColor;
                    break;

                case TreeView tv:
                    tv.BackColor = _currentTheme.ControlBackground;
                    tv.ForeColor = _currentTheme.ForeColor;
                    break;

                case DataGridView dgv:
                    dgv.BackgroundColor = _currentTheme.FormBackground;
                    dgv.DefaultCellStyle.BackColor = _currentTheme.ControlBackground;
                    dgv.DefaultCellStyle.ForeColor = _currentTheme.ForeColor;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = _currentTheme.MenuBackground;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = _currentTheme.ForeColor;
                    dgv.RowHeadersDefaultCellStyle.BackColor = _currentTheme.MenuBackground;
                    dgv.RowHeadersDefaultCellStyle.ForeColor = _currentTheme.ForeColor;
                    dgv.GridColor = _currentTheme.BorderColor;
                    break;

                case NumericUpDown nud:
                    nud.BackColor = _currentTheme.ControlBackground;
                    nud.ForeColor = _currentTheme.ForeColor;
                    break;

                case CheckBox chk:
                    chk.ForeColor = _currentTheme.ForeColor;
                    break;

                case RadioButton rb:
                    rb.ForeColor = _currentTheme.ForeColor;
                    break;

                // LinkLabel must come before Label since it inherits from Label
                case LinkLabel ll:
                    ll.LinkColor = _currentTheme.AccentColor;
                    ll.VisitedLinkColor = _currentTheme.AccentColor;
                    ll.ActiveLinkColor = _currentTheme.HoverColor;
                    break;

                case Label lbl:
                    // Only set ForeColor, labels often have transparent backgrounds
                    lbl.ForeColor = _currentTheme.ForeColor;
                    break;

                // TabPage must come before Panel since it inherits from Panel
                case TabPage tp:
                    tp.BackColor = _currentTheme.FormBackground;
                    tp.ForeColor = _currentTheme.ForeColor;
                    break;

                case Panel panel:
                    // Panels often serve as containers, use form background
                    panel.BackColor = _currentTheme.FormBackground;
                    break;

                case TabControl tc:
                    tc.BackColor = _currentTheme.FormBackground;
                    break;

                case ProgressBar:
                    // ProgressBar styling is limited in WinForms
                    break;

                case PictureBox:
                    // Don't modify PictureBoxes - they're for images
                    break;

                case WebBrowser:
                    // WebBrowser has its own theming
                    break;

                case UserControl uc:
                    uc.BackColor = _currentTheme.FormBackground;
                    uc.ForeColor = _currentTheme.ForeColor;
                    break;

                default:
                    // For any other control, try to set basic colors
                    try
                    {
                        control.BackColor = _currentTheme.FormBackground;
                        control.ForeColor = _currentTheme.ForeColor;
                    }
                    catch
                    {
                        // Some controls don't support setting these properties
                    }
                    break;
            }
        }
    }
}
