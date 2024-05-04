using IngameScript.IngameScript.Pulse.Loggers;
using IngameScript.Pulse.Constants;
using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using VRage.Game.ModAPI.Ingame.Utilities;

namespace IngameScript 
{   
    partial class Program: MyGridProgram
    {
        public readonly PanelLogger Logger;

        public readonly MyIni Config;

        public readonly string Tag;

        public readonly Dictionary<string, Action<string>> TerminalActions = new Dictionary<string, Action<string>>();

        public Program()
        {
            Config = new MyIni();
            if (!Config.TryParse(Me.CustomData)) throw new ArgumentException("Can't parse config." + Me.CustomData);

            Tag = Config.Get("Grid","Tag").ToString();

            var panel = GridTerminalSystem.GetBlockWithName(Tag + Config.Get("Grid", "LogPanel").ToString()) as IMyTextPanel;

            Logger = new PanelLogger(panel);

            Init();
        }

        public void Main(string argument, UpdateType updateSource)
        {
            EchoStatistic(updateSource);

            try
            {
                if (updateSource == UpdateType.Terminal || updateSource == UpdateType.Trigger)
                {
                    var arr = argument.Split(';');

                    Action<string> action;
                    if (!TerminalActions.TryGetValue(arr[0], out action)) throw new Exception($"Unknown command. Check command or subscribe your command to {nameof(TerminalActions)} Argument: {argument}");

                    action.Invoke(argument);
                }
                else
                {
                    Execute(argument, updateSource);
                }
            }
            catch (Exception ex)
            {
                Logger.AddLine($"Got Exception: {ex}");

                RestartAfterException();
            }
        }

        private void RestartAfterException()
        {
            if (Constant.RESTART_SCRIPT_AFTER_EXCEPTION)
            {
                Logger.AddLine($"\nRestarting the script");
            }
            else
            {
                Logger.AddLine($"\nThe script execution is stoped");

                Runtime.UpdateFrequency = UpdateFrequency.None;
            }
        }

        private void EchoStatistic(UpdateType updateSource)
        {
            Echo($"{DateTime.Now:HH:mm:ss}");

            Echo($"From: {updateSource}");
        }
    }
}