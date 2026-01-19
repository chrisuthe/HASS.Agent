using System;
using System.Windows.Forms;
using HASS.Agent.Shared.Enums;
using Serilog;

namespace HASS.Agent.Shared.HomeAssistant.Commands.CustomCommands
{
    /// <summary>
    /// Command to put Windows in sleep using WinForms API
    /// Alternative to SleepCommand which uses Rundll32
    /// </summary>
    public class WinformsSleepCommand : InternalCommand
    {
        private const string DefaultName = "winformssleep";

        public WinformsSleepCommand(string entityName = DefaultName, string name = DefaultName, CommandEntityType entityType = CommandEntityType.Button, string id = default)
            : base(entityName ?? DefaultName, name ?? null, string.Empty, entityType, id)
        {
            State = "OFF";
        }

        public override void TurnOn()
        {
            State = "ON";

            try
            {
                // Use WinForms API to put system to sleep
                // forceCritical=false means it can be canceled by other apps
                // disableWakeEvent=false means wake timers are allowed
                Application.SetSuspendState(PowerState.Suspend, force: false, disableWakeEvent: false);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "[WINFORMSSLEEP] Error putting system to sleep: {err}", ex.Message);
            }

            State = "OFF";
        }
    }
}
