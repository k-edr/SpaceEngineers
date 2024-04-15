using IngameScript.Const;
using IngameScript.Logger;
using IngameScript.MyGridSystem;
using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {
 
        public MyGrid GridBlocks;

        public ILogger Logger;

        private void StuffInit() 
        {
            string GridGroupName = Me.CustomData.Split('\n')[0];

            GridBlocks = new MyGrid(GridTerminalSystem.GetBlockGroupWithName(GridGroupName));

            Logger = new PanelLogger(GridBlocks.GetBlockWithName("LogPanel") as IMyTextPanel);

            (Logger as PanelLogger).Clear();
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
