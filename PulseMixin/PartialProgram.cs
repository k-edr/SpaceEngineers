using IngameScript.IngameScript.Pulse.Services;
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

        public readonly Dictionary<string, Action<string>> TerminalTriggerArgumentActions = new Dictionary<string, Action<string>>();

        public readonly IMyTerminalBlock[] MyGridBlocks;

        public Program()
        {
            Config = new MyIni();
            if (!Config.TryParse(Me.CustomData)) throw new ArgumentException("Can't parse config." + Me.CustomData);

            Tag = Config.Get("Grid", "Tag").ToString();

            var tempList = new List<IMyTerminalBlock>();

            GridTerminalSystem.SearchBlocksOfName(Tag, tempList);

            MyGridBlocks = tempList.ToArray();

            var panel = GridTerminalSystem.GetBlockWithName(Tag + Config.Get("Grid", "LogPanel").ToString()) as IMyTextPanel;

            Logger = new PanelLogger(panel);

            Logger.Clear();

            AddDictionaryActions();

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
                    if (!TerminalTriggerArgumentActions.TryGetValue(arr[0], out action)) throw new ArgumentException($"Unknown command. Check argument or subscribe your command to {nameof(TerminalTriggerArgumentActions)} Argument: {argument}");

                    Logger.AddLine($"Execute command: {arr[0]}\nArgument: {argument}");

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

        private void AddDictionaryActions()
        {
            var blocks = new List<IMyTerminalBlock>();
            GridTerminalSystem.GetBlocks(blocks);

            TerminalTriggerArgumentActions.Add("AutoTag_Add",
                (argument) =>
                {
                    string tag = argument.Split(';')[1];
                    AutoTag.Add(tag, blocks.ToArray());
                });

            TerminalTriggerArgumentActions.Add("AutoTag_Remove",
                (argument) =>
                {
                    string tag = argument.Split(';')[1];
                    AutoTag.Remove(tag, blocks.ToArray());
                });
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