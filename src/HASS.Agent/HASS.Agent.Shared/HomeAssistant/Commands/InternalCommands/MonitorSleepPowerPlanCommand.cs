using System;
using System.Diagnostics;
using System.Threading;
using HASS.Agent.Shared.Enums;
using Serilog;

namespace HASS.Agent.Shared.HomeAssistant.Commands.InternalCommands
{
    /// <summary>
    /// Command to put all monitors to sleep by temporarily modifying the power plan
    /// This approach turns off the monitor without putting the PC to sleep
    /// </summary>
    public class MonitorSleepPowerPlanCommand : InternalCommand
    {
        private const string DefaultName = "monitorsleep-pp";
        private const string TempPlanName = "HASS.Agent Monitor Sleep";

        public MonitorSleepPowerPlanCommand(string entityName = DefaultName, string name = DefaultName, CommandEntityType entityType = CommandEntityType.Button, string id = default)
            : base(entityName ?? DefaultName, name ?? null, string.Empty, entityType, id)
        {
            State = "OFF";
        }

        public override void TurnOn()
        {
            State = "ON";

            try
            {
                // Get current active power scheme GUID
                var activeSchemeGuid = GetActiveSchemeGuid();
                if (string.IsNullOrEmpty(activeSchemeGuid))
                {
                    Log.Warning("[MONITORSLEEP-PP] Could not get active power scheme");
                    State = "OFF";
                    return;
                }

                // Clean up any existing temp scheme
                CleanupTempScheme();

                // Duplicate the active scheme
                var tempSchemeGuid = DuplicateScheme(activeSchemeGuid);
                if (string.IsNullOrEmpty(tempSchemeGuid))
                {
                    Log.Warning("[MONITORSLEEP-PP] Could not duplicate power scheme");
                    State = "OFF";
                    return;
                }

                try
                {
                    // Rename the temp scheme
                    RunPowercfg($"-changename {tempSchemeGuid} \"{TempPlanName}\"");

                    // Set video timeout to 1 second (AC power)
                    RunPowercfg($"-setacvalueindex {tempSchemeGuid} 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 1");

                    // Set video timeout to 1 second (DC/battery power)
                    RunPowercfg($"-setdcvalueindex {tempSchemeGuid} 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 1");

                    // Activate the temp scheme
                    RunPowercfg($"-setactive {tempSchemeGuid}");

                    // Wait for monitor to turn off
                    Thread.Sleep(1500);

                    // Restore the original scheme
                    RunPowercfg($"-setactive {activeSchemeGuid}");
                }
                finally
                {
                    // Clean up temp scheme
                    CleanupTempScheme();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "[MONITORSLEEP-PP] Error putting monitors to sleep: {err}", ex.Message);
            }

            State = "OFF";
        }

        private static string GetActiveSchemeGuid()
        {
            try
            {
                var output = RunPowercfg("-getactivescheme");
                // Output format: "Power Scheme GUID: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx  (name)"
                var match = System.Text.RegularExpressions.Regex.Match(output, @"([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})");
                return match.Success ? match.Value : null;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "[MONITORSLEEP-PP] Error getting active scheme: {err}", ex.Message);
                return null;
            }
        }

        private static string DuplicateScheme(string sourceGuid)
        {
            try
            {
                var output = RunPowercfg($"-duplicatescheme {sourceGuid}");
                // Output format: "Power Scheme GUID: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx  (name)"
                var match = System.Text.RegularExpressions.Regex.Match(output, @"([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})");
                return match.Success ? match.Value : null;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "[MONITORSLEEP-PP] Error duplicating scheme: {err}", ex.Message);
                return null;
            }
        }

        private static void CleanupTempScheme()
        {
            try
            {
                // List all schemes and find any with our temp name
                var output = RunPowercfg("-list");
                var lines = output.Split('\n');

                foreach (var line in lines)
                {
                    if (line.Contains(TempPlanName))
                    {
                        var match = System.Text.RegularExpressions.Regex.Match(line, @"([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})");
                        if (match.Success)
                        {
                            RunPowercfg($"-delete {match.Value}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "[MONITORSLEEP-PP] Error cleaning up temp scheme: {err}", ex.Message);
            }
        }

        private static string RunPowercfg(string arguments)
        {
            using var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powercfg",
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }
    }
}
