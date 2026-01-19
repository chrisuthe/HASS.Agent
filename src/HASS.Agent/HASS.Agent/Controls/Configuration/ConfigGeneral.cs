using System.Globalization;
using HASS.Agent.Functions;

namespace HASS.Agent.Controls.Configuration
{
    public partial class ConfigGeneral : ThemeAwareUserControl
    {
        public ConfigGeneral()
        {
            InitializeComponent();

            BindComboBoxTheme();
        }

        private void BindComboBoxTheme() => CbLanguage.DrawItem += ComboBoxTheme.DrawItem;

        private void ConfigGeneral_Load(object sender, EventArgs e)
        {
            // load all languages
            foreach (var lang in Variables.SupportedUILanguages) CbLanguage.Items.Add(lang.DisplayName);

            // select the current one
            CbLanguage.SelectedItem = Variables.CurrentUICulture.DisplayName;
        }
    }
}
