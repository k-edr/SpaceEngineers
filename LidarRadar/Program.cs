using System;
using System.Collections.Generic;
using IngameScript.Const;
using IngameScript.Custom;
using IngameScript.Logger;
using IngameScript.MyGridSystem;
using Sandbox.ModAPI.Ingame;
using VRageMath;

namespace IngameScript
{
    partial class Program : MyGridProgram, ITemplate
    {
        public LidarController LidarController;

        public void Init()
        {
            Runtime.UpdateFrequency = UpdateFrequency.Update1;

            var cameras = new List<IMyCameraBlock>();

            GridBlocks.GetBlocksOfType(cameras);

            var scanDistance = Config.Get("Grid", "ScanDistanceLimit").ToInt32();

            var Lidar = new Lidar(Logger ,cameras, scanDistance);

            LidarController = new LidarController(
                new LidarModel() { Lidar = Lidar },
                new LidarView(
                    textPanel: GridBlocks.GetBlockWithName(Config.Get("Grid", "LidarDisplayName").ToString()) as IMyTextPanel));
        }

        public bool tryLock = false;
        public void Execute(string argument, UpdateType updateSource)
        {

            if(updateSource == UpdateType.Trigger || updateSource == UpdateType.Terminal)
            {
                switch (argument)
                {
                    case "TryLock":

                        tryLock = true;

                        break;
                    case "StopLock":

                        tryLock = false;

                        break;
                    default:

                        Echo("Unknown argument: " + argument);

                        Logger.AddLine("Unknown argument: " + argument);

                        return;
                }

                Logger.AddLine("Executed command: " + argument);
            }
            else
            {
                if (tryLock)
                {
                    LidarController.Scan();
                    LidarController.UpdateView();
                }
            }      
        }
    }
}
