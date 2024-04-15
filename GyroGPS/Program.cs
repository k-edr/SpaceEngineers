using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
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
using VRageMath;

namespace IngameScript
{


    partial class Program : MyGridProgram
    {
        GPSRotatorController _controller;

        GPSModel gpsCords;

        float mult = 10;
        public Program()
        {
            Runtime.UpdateFrequency = UpdateFrequency.Update1;

            var gyroModel = new GyroModel()
            {
                Gyro = GridTerminalSystem.GetBlockWithName("Gyroscope") as IMyGyro
            };
            _controller = new GPSRotatorController(gyroModel, GridTerminalSystem.GetBlockWithName("Remote Control") as IMyShipController);

        }

        public void Save()
        {
            
        }

        public void Main(string argument, UpdateType updateSource)
        {
            if (updateSource == UpdateType.Terminal)
            {
                _controller.SetGyroOverride(true, _controller.GetNavAngles((gpsCords = new GPSModel(argument)).GetVector3D), 1);
            }
            else
            {
                _controller.SetGyroOverride(true, _controller.GetNavAngles(gpsCords.GetVector3D) *mult, 1);
            }
        }

        
    }
}