using System;
using IngameScript.Const;
using IngameScript.Custom;
using IngameScript.Logger;
using IngameScript.MyGridSystem;
using IngameScript.Stuff.Logger;
using Sandbox.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {
 
        public MyGrid GridBlocks;

        public ILogger Logger;

        public MyIni Config;

        public Program() 
        {
            Config = new MyIni();

            MyIniParseResult result;
            if (!Config.TryParse(Me.CustomData, out result))
                throw new Exception(result.ToString());

            var gridGroupName = Config.Get("Grid", "GroupName").ToString();

            GridBlocks = new MyGrid(GridTerminalSystem.GetBlockGroupWithName(gridGroupName));

            Logger = new PanelLogger(GridBlocks.GetBlockWithName("LogPanel") as IMyTextPanel);

            (Logger as PanelLogger).Clear();

            Init();
        }

        public void Main(string argument, UpdateType updateSource)
        {
            Echo($"{DateTime.Now:HH:mm:ss}");

            Echo($"From: {updateSource}");

            try
            {
                Execute(argument, updateSource);
            }
            catch (Exception ex)
            {
                Logger.Add($"Got Exception: {ex}");

                if (Constants.RESTART_SCRIPT_AFTER_EXCEPTION)
                {
                    Logger.Add($"\nRestarting the script");
                }
                else
                {
                    Logger.Add($"\nThe script execution is stoped");

                    Runtime.UpdateFrequency = UpdateFrequency.None;
                }
            }
        }
    }
}
