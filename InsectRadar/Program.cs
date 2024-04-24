using IngameScript.Controllers;
using IngameScript.Custom;
using IngameScript.Models;
using IngameScript.Services;
using IngameScript.Views;
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

        MyltiTargetRadarController MyltiTargetRadarController;
        ScanPlot scanPlot;

        public void Init()
        {
            Runtime.UpdateFrequency = UpdateFrequency.Update1;

            var cameras = new List<IMyCameraBlock>();

            var temp = new List<IMyTerminalBlock>();

            GridTerminalSystem.GetBlockGroupWithName(Config.Get("Grid", "RadarPlot1").ToString()).GetBlocks(temp);

            temp.Where(x => x is IMyCameraBlock).ToList().ForEach((val) => { cameras.Add(val as IMyCameraBlock); });

            scanPlot = new ScanPlot(Logger, cameras);

            Logger.AddLine($"Inited plot {Config.Get("Grid", "RadarPlot1")}");
            Logger.AddLine($"Inited plot cameras. Total inited: {cameras.Count} cameras");

            MyltiTargetRadarController = new MyltiTargetRadarController(
                new MultiTargetRadarModel() { Radar = new MultiTargetRadar(scanPlot, Runtime) }, 
                new MultiTargetRadarView(GridBlocks.GetBlockWithName(Config.Get("Grid", "RadarDisplay").ToString()) as IMyTextPanel));

        }

        bool tryScan = false;
        bool tryLockNewTarget = false;
        bool newTargetIsLocked = false;

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
                        MyltiTargetRadarController.ResetRadar();
                        tryScan = false;
                        break;
                    case "TryLockNewTarget":
                        tryLockNewTarget = true;
                        newTargetIsLocked = false;
                        break;
                    default:
                        throw new ArgumentException("Unknown argument", argument);
                }
            }

            if (tryScan)
            {
                MyltiTargetRadarController.TryLock();
                MyltiTargetRadarController.Show();

                Logger.AddLine("Range " + scanPlot.GetTotalAvailableRange);
            }
            if (tryLockNewTarget)
            {
                MyltiTargetRadarController.TryLockNewTarget(ref newTargetIsLocked);
                if (newTargetIsLocked)
                {
                    tryLockNewTarget = false;
                }
            }
        }

        
    }
}
