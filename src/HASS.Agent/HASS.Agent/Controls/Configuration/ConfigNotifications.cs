using HASS.Agent.API;
using HASS.Agent.Functions;
using HASS.Agent.Managers;
using HASS.Agent.Models.HomeAssistant;
using HASS.Agent.Resources.Localization;
using Serilog;

namespace HASS.Agent.Controls.Configuration
{
    public partial class ConfigNotifications : ThemeAwareUserControl
    {
        public ConfigNotifications()
        {
            InitializeComponent();
        }

        private void BtnNotificationsReadme_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://www.hass-agent.io/latest/getting-started/notifications/");

        private void BtnSendTestNotification_Click(object sender, EventArgs e)
        {
            if (!Variables.AppSettings.NotificationsEnabled)
            {
                MessageBox.Show(this, Languages.ConfigNotifications_BtnSendTestNotification_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var testNotification = new Notification
            {
                Message = Languages.ConfigNotifications_TestNotification,
                Title = "HASS.Agent",
                Data = new NotificationData()
                {
                    Image = "https://cdn.pixabay.com/photo/2017/07/25/01/22/cat-2536662_960_720.jpg",
                    Actions = new List<NotificationAction>()
                    {
                        new NotificationAction(){ Action = "hass_test_yesAction", Title = Languages.ConfigNotifications_TestNotification_Yes},
                        new NotificationAction(){ Action = "hass_test_noAction", Title = Languages.ConfigNotifications_TestNotification_No}
                    },
                    Inputs = new List<NotificationInput>()
                    {
                        new NotificationInput(){ Id = "hass_test_input",
                        Title = Languages.ConfigNotifications_TestNotification_InputTitle,
                        Text = Languages.ConfigNotifications_TestNotification_InputText}
                    }
                }
            };

            Log.Information("[NOTIFIER] Attempting to show test notification ..");

            NotificationManager.ShowNotification(testNotification);

            Log.Information("[NOTIFIER] Test notification attempt completed");

            MessageBox.Show(this, Languages.ConfigNotifications_BtnSendTestNotification_MessageBox2,
                Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ConfigNotifications_Load(object sender, EventArgs e)
        {
            LblConnectivityDisabled.Visible = !Variables.AppSettings.LocalApiEnabled && !Variables.AppSettings.MqttEnabled;
        }
    }
}
