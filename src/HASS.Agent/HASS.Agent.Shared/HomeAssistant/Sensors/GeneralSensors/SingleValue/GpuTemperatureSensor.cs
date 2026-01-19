using HASS.Agent.Shared.Models.HomeAssistant;
using Serilog;

namespace HASS.Agent.Shared.HomeAssistant.Sensors.GeneralSensors.SingleValue
{
    /// <summary>
    /// Sensor containing the current GPU temp.
    /// DISABLED: GPU monitoring removed due to WinRing0 vulnerability (CVE-2020-14979).
    /// </summary>
    public class GpuTemperatureSensor : AbstractSingleValueSensor
    {
        private const string DefaultName = "gputemperature";
        private static bool _warningLogged = false;

        public GpuTemperatureSensor(int? updateInterval = null, string entityName = DefaultName, string name = DefaultName, string id = default, string advancedSettings = default) : base(entityName ?? DefaultName, name ?? null, updateInterval ?? 30, id, advancedSettings: advancedSettings)
        {
            if (!_warningLogged)
            {
                Log.Warning("[GPU_TEMP_SENSOR] GPU temperature monitoring is no longer available. " +
                    "LibreHardwareMonitorLib was removed due to WinRing0 vulnerability (CVE-2020-14979). " +
                    "See: https://nvd.nist.gov/vuln/detail/CVE-2020-14979");
                _warningLogged = true;
            }
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            if (Variables.MqttManager == null) return null;

            var deviceConfig = Variables.MqttManager.GetDeviceConfigModel();
            if (deviceConfig == null) return null;

            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                EntityName = EntityName,
                Name = Name,
                Unique_id = Id,
                Device = deviceConfig,
                State_topic = $"{Variables.MqttManager.MqttDiscoveryPrefix()}/{Domain}/{deviceConfig.Name}/{ObjectId}/state",
                Device_class = "temperature",
                Unit_of_measurement = "°C",
                State_class = "measurement",
                Availability_topic = $"{Variables.MqttManager.MqttDiscoveryPrefix()}/{Domain}/{deviceConfig.Name}/availability"
            });
        }

        public override string GetState() => null;

        public override string GetAttributes() => string.Empty;
    }
}
