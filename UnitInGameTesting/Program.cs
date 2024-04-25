using IngameScript.Custom;
using IngameScript.UnitTesting;
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

    
    partial class Program : MyGridProgram, ITemplate
    {
        TestExecutor TestExecutor;
        public void Init()
        {
            Runtime.UpdateFrequency = UpdateFrequency.Update10;

            var collector = new TestCollector();
            collector.Add(new MyTests());

            Logger.AddLine(string.Join(" ", collector.GetTests()));

            TestExecutor = new TestExecutor(collector.GetTests(),Echo);
        }
        public void Execute(string argument, UpdateType updateSource)
        {
            TestExecutor.ExecuteNext();

            if(argument == "ShowResults")
            {
                foreach (var item in TestExecutor.TestsResult)
                {
                    Logger.Add(item._summary.Get());
                }
            }
        }
    }
}
