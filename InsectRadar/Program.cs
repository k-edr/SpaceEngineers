using IngameScript.Custom;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using VRage;
using VRage.Collections;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;

namespace IngameScript
{
    partial class Program : MyGridProgram, ITemplate
    {

        RadarController RadarController;

        public void Init()
        {
            Runtime.UpdateFrequency = UpdateFrequency.Update10;

            var cameras = new List<IMyCameraBlock>();

            var temp = new List<IMyTerminalBlock>();

            GridTerminalSystem.GetBlockGroupWithName(Config.Get("Grid", "RadarPlot1").ToString()).GetBlocks(temp);

            temp.Where(x => x is IMyCameraBlock).ToList().ForEach((val) => { cameras.Add(val as IMyCameraBlock); });

            var scanPlot = new ScanPlot(Logger, cameras);

            Logger.AddLine($"Inited plot {Config.Get("Grid", "RadarPlot1")}");
            Logger.AddLine($"Inited plot cameras. Total inited: {cameras.Count} cameras");

            RadarController = new RadarController(
                new RadarModel() { Radar = new Radar(scanPlot, Runtime) }, 
                new RadarView(GridBlocks.GetBlockWithName(Config.Get("Grid", "RadarDisplay").ToString()) as IMyTextPanel));

        }

        bool tryScan = false;

        public void Execute(string argument, UpdateType updateSource)
        {
            if(UpdateType.Trigger == updateSource || UpdateType.Terminal == updateSource)
            {
                switch (argument)
                {
                    case "TryLock":
                        tryScan = true;
                        break;
                    case "StopLock":
                        tryScan = false;
                        break;
                    case "ResetRadar":
                        RadarController.ResetRadar();
                        tryScan = false;

                        break;
                    default:
                        throw new ArgumentException("Unknown argument", argument);
                }
            }

            if (tryScan)
            {
                RadarController.TryLock();
                RadarController.Show();

            }
        }

        
    }
}
