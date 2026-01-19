using System;
using System.Runtime.InteropServices;
using System.Text;
using HASS.Agent.Shared.Models.HomeAssistant;

namespace HASS.Agent.Shared.HomeAssistant.Sensors.GeneralSensors.SingleValue
{
    /// <summary>
    /// Binary sensor indicating whether the currently focused window contains the configured name
    /// </summary>
    public class NamedActiveWindowSensor : AbstractSingleValueSensor
    {
        private const string DefaultName = "namedactivewindow";
        public string WindowName { get; protected set; }

        public NamedActiveWindowSensor(string windowName, string entityName = DefaultName, string name = DefaultName, int? updateInterval = 10, string id = default, string advancedSettings = default)
            : base(entityName ?? DefaultName, name ?? null, updateInterval ?? 10, id, advancedSettings: advancedSettings)
        {
            Domain = "binary_sensor";
            WindowName = windowName;
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            if (Variables.MqttManager == null)
                return null;

            var deviceConfig = Variables.MqttManager.GetDeviceConfigModel();
            if (deviceConfig == null)
                return null;

            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                EntityName = EntityName,
                Name = Name,
                Unique_id = Id,
                Device = deviceConfig,
                State_topic = $"{Variables.MqttManager.MqttDiscoveryPrefix()}/{Domain}/{deviceConfig.Name}/{ObjectId}/state",
                Availability_topic = $"{Variables.MqttManager.MqttDiscoveryPrefix()}/sensor/{deviceConfig.Name}/availability"
            });
        }

        public override string GetState()
        {
            var windowHandle = GetForegroundWindow();
            var windowTitle = GetWindowTitle(windowHandle);

            return windowTitle.Contains(WindowName, StringComparison.OrdinalIgnoreCase) ? "ON" : "OFF";
        }

        public override string GetAttributes() => string.Empty;

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder builder, int count);

        private static string GetWindowTitle(IntPtr windowHandle)
        {
            var titleLength = GetWindowTextLength(windowHandle) + 1;
            var builder = new StringBuilder(titleLength);
            var windowTitle = GetWindowText(windowHandle, builder, titleLength) > 0 ? builder.ToString() : string.Empty;

            // Limit to 255 characters to comply with HA payload limit
            return windowTitle.Length > 255 ? windowTitle[..255] : windowTitle;
        }
    }
}
