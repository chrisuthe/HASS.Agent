using HASS.Agent.HomeAssistant;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Shared.Functions;

namespace HASS.Agent.Controls.Onboarding
{
    // ReSharper disable once InconsistentNaming
    public partial class OnboardingApi : ThemeAwareUserControl
    {
        public OnboardingApi()
        {
            InitializeComponent();
        }

        private void OnboardingApi_Load(object sender, EventArgs e)
        {
            TbHassIp.Text = Variables.AppSettings.HassUri;
            TbHassApiToken.Text = Variables.AppSettings.HassToken;

            ActiveControl = TbHassApiToken;
        }

        internal bool Store()
        {
            Variables.AppSettings.HassUri = TbHassIp.Text;
            Variables.AppSettings.HassToken = TbHassApiToken.Text;
            return true;
        }

        private async void BtnTest_Click(object sender, EventArgs e)
        {
            // test entered values
            var apiKey = TbHassApiToken.Text.Trim();
            var hassUri = TbHassIp.Text.Trim();

            if (string.IsNullOrEmpty(apiKey))
            {
                MessageBox.Show(this, Languages.OnboardingApi_BtnTest_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbHassApiToken;
                return;
            }

            if (string.IsNullOrEmpty(hassUri))
            {
                MessageBox.Show(this, Languages.OnboardingApi_BtnTest_MessageBox2, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbHassIp;
                return;
            }

            if (!SharedHelperFunctions.CheckHomeAssistantApiToken(apiKey))
            {
                var q = MessageBox.Show(this, Languages.OnboardingApi_BtnTest_MessageBox5, Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (q != DialogResult.Yes)
                {
                    ActiveControl = TbHassApiToken;
                    return;
                }
            }

            if (!SharedHelperFunctions.CheckHomeAssistantUri(hassUri))
            {
                var q = MessageBox.Show(this, Languages.OnboardingApi_BtnTest_MessageBox6, Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (q != DialogResult.Yes)
                {
                    ActiveControl = TbHassIp;
                    return;
                }
            }

            // lock gui
            TbHassIp.Enabled = false;
            TbHassApiToken.Enabled = false;
            BtnTest.Enabled = false;
            BtnTest.Text = Languages.OnboardingApi_BtnTest_Testing;
            
            // perform test
            var (success, message) = await HassApiManager.CheckHassConfigAsync(hassUri, apiKey);
            if (!success) MessageBox.Show(this, string.Format(Languages.OnboardingApi_BtnTest_MessageBox3, message), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MessageBox.Show(this, string.Format(Languages.OnboardingApi_BtnTest_MessageBox4, message), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            // unlock gui
            TbHassIp.Enabled = true;
            TbHassApiToken.Enabled = true;
            BtnTest.Enabled = true;
            BtnTest.Text = Languages.OnboardingApi_BtnTest;
        }
    }
}
