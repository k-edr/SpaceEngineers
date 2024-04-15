using IngameScript.Logger;
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
using IngameScript.Const;
using IngameScript.Torpedo.Speed;
using IngameScript.Torpedo.Rotation;
using IngameScript.Torpedo;
using IngameScript.Helpers;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {
        public readonly string GridTag;

        public ILogger Logger;

        public AtmoSpeedController AtmoSpeedController;

        public RotatorController RotatorController;

        public IMyShipController MyShipController;

        public FlyingPlan FlyingPlan;

        public Program()
        {
            Runtime.UpdateFrequency = UpdateFrequency.Once;

            var arr = Me.CustomData.Split('\n');

            GridTag = arr[0];

            Logger = new PanelLogger(GridTerminalSystem.GetBlockWithName(GridTag + "LogPanel") as IMyTextPanel);

            (Logger as PanelLogger).Clear();

            MyShipController = GridTerminalSystem.GetBlockWithName(GridTag + "Remote Control") as IMyShipController;

            AtmoSpeedController = new AtmoSpeedController(Logger, MyShipController, 150, 400);

            AtmoSpeedController.Add(GridTerminalSystem.GetBlockWithName(GridTag + "Hydrogen Thruster 2") as IMyThrust);
            AtmoSpeedController.Add(GridTerminalSystem.GetBlockWithName(GridTag + "Hydrogen Thruster 3") as IMyThrust);
            AtmoSpeedController.Add(GridTerminalSystem.GetBlockWithName(GridTag + "Hydrogen Thruster 4") as IMyThrust);

            RotatorController = new RotatorController(Logger, MyShipController);

            RotatorController.Add(GridTerminalSystem.GetBlockWithName(GridTag + "Gyroscope") as IMyGyro);

            FlyingPlan = new FlyingPlan();

            for (int i = 1; i < arr.Length; i++)
            {
                FlyingPlan.EnqueuePoint(GPSParser.Parse(arr[i]));
            }
        }

        public void Save()
        {

        }

        public void Main(string argument, UpdateType updateSource)
        {
            Echo($"{GridTag}");
            Echo($"{DateTime.Now.ToString("HH:mm:ss")}");
            Echo($"{updateSource}");

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

        static bool isLaunched = false;

        public void Execute(string argument, UpdateType updateSource)
        {


            if (updateSource == UpdateType.Trigger || updateSource == UpdateType.Terminal)
            {
                var arr = argument.Split(';');
                switch (arr[0])
                {
                    case "Launch":
                        isLaunched = true;
                        (GridTerminalSystem.GetBlockWithName(GridTag + "Automaton Timer Block") as IMyTimerBlock).Trigger();
                        Runtime.UpdateFrequency = UpdateFrequency.Update1;
                        break;
                }
            }
            else
            {
                if (isLaunched)
                {
                    Echo($"Current point: {FlyingPlan.PeekPoint()}");
                    Echo($"Points count: {FlyingPlan.Count()}");

                    if (Vector3D.Distance(MyShipController.GetPosition(), FlyingPlan.PeekPoint()) <= 2000d)
                    {
                        FlyingPlan.DequeuePoint();
                    }

                    AtmoSpeedController.ControllSpeed();

                    RotatorController.RotateTo(FlyingPlan.PeekPoint());
                }
            }
        }
    }
}
