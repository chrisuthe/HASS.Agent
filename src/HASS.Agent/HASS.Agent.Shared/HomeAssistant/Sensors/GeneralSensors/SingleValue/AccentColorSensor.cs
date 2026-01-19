using System.Runtime.InteropServices;
using HASS.Agent.Shared.Models.HomeAssistant;

namespace HASS.Agent.Shared.HomeAssistant.Sensors.GeneralSensors.SingleValue
{
    /// <summary>
    /// Sensor containing the current Windows accent color as #RRGGBB hex value
    /// </summary>
    public class AccentColorSensor : AbstractSingleValueSensor
    {
        private const string DefaultName = "accentcolor";

        public AccentColorSensor(int? updateInterval = null, string entityName = DefaultName, string name = DefaultName, string id = default, string advancedSettings = default)
            : base(entityName ?? DefaultName, name ?? null, updateInterval ?? 300, id, advancedSettings: advancedSettings) { }

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
                Icon = "mdi:palette",
                Availability_topic = $"{Variables.MqttManager.MqttDiscoveryPrefix()}/{Domain}/{deviceConfig.Name}/availability"
            });
        }

        public override string GetState()
        {
            try
            {
                var result = DwmGetColorizationColor(out var color, out _);
                if (result != 0)
                    return "unknown";

                // Extract RGB components from ARGB value
                var r = (color >> 16) & 0xFF;
                var g = (color >> 8) & 0xFF;
                var b = color & 0xFF;

                return $"#{r:X2}{g:X2}{b:X2}";
            }
            catch
            {
                return "unknown";
            }
        }

        public override string GetAttributes() => string.Empty;

        [DllImport("dwmapi.dll", PreserveSig = true)]
        private static extern int DwmGetColorizationColor(out uint colorizationColor, out bool colorizationOpaqueBlend);
    }
}
