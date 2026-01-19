namespace HASS.Agent.Shared.Managers;

/// <summary>
/// Hardware monitoring has been disabled due to WinRing0 vulnerability (CVE-2020-14979).
/// GPU sensors are no longer available.
/// See: https://nvd.nist.gov/vuln/detail/CVE-2020-14979
/// </summary>
public static class HardwareManager
{
	public static void Initialize() { }
	public static void Shutdown() { }
}
