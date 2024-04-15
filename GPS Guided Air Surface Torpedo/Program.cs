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
using VRageMath;

namespace IngameScript
{

    partial class Program : MyGridProgram
    {
        const bool RELAUNCH_AFTER_FALLING = false;

        TorpedoController torpedo;
        SpeedController speed;

        string TorpedoTag = "[Torpedo]";
        bool launchPressed = false;

        public Program()
        {
            TorpedoTag = Me.CustomData.Split('\n')[1];

            Runtime.UpdateFrequency = UpdateFrequency.Once;
            torpedo = new TorpedoController() {
                Model = new TorpedoModel() {
                    Tag = TorpedoTag,
                    LaunchTimer = GridTerminalSystem.GetBlockWithName(TorpedoTag + "OutOf") as IMyTimerBlock,
                    Target = new GPSModel(Me.CustomData.Split('\n')[0])},
                Rotator = new GPSRotatorController(
                    new GyroModel() { 
                        Gyro = GridTerminalSystem.GetBlockWithName(TorpedoTag + "Gyroscope") as IMyGyro },
                    GridTerminalSystem.GetBlockWithName(TorpedoTag + "Remote Control") as IMyShipController
                    )};
            speed = new SpeedController(thrust: GridTerminalSystem.GetBlockWithName(TorpedoTag + "Hydrogen Thruster 5") as IMyThrust,low: 50,top: 450);


            Echo("Set target: " + Me.CustomData);
        }

        public void Save()
        {

        }

        public void Main(string argument, UpdateType updateSource)
        {
            try {
                Execute(argument, updateSource);
            } catch (Exception ex)
            {
                Echo($"Program downed. The program Exception:{ex}");
            }
            finally
            {
                if (!RELAUNCH_AFTER_FALLING)
                {
                    //Runtime.UpdateFrequency = UpdateFrequency.None;
                }
            }
        }


        public void Execute(string argument, UpdateType updateSource)
        {
            var commands = argument.Split(';');

            if (argument != string.Empty)
            {
                switch (commands[0])
                {
                    case "Torpedo":
                        Echo("Executed Torpedo");
                        switch (commands[1])
                        {
                            case "Launch":
                                Echo("Executed Launch");
                                Runtime.UpdateFrequency = UpdateFrequency.Update1;
                                launchPressed = true;
                                torpedo.Launch();
                                break;
                            //case "SetTarget":
                            //    Echo("Executed SetTarget");
                            //    Echo("Target is:" + commands[2]);
                            //    torpedo.SetCoordinats(new GPSModel(commands[2]));
                            //    break;
                            default:
                                break;
                        }

                        break;
                    default:
                        throw new ArgumentException($"Unknown command: {argument}");
                }
            }
            else
            {
                if (launchPressed)
                {

                    torpedo.Rotator.SetGyroOverride(true, torpedo.Rotator.GetNavAngles(torpedo.Model.Target.GetVector3D), 1);
                    speed.ControllThruster((float)torpedo.Rotator._shipController.GetShipSpeed());
                    Echo($"Speed is: {(float)torpedo.Rotator._shipController.GetShipSpeed()}");
                    Echo($"{DateTime.Now.TimeOfDay} Moving to...");
                }
            }
        } 
    }
}

