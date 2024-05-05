using IngameScript.Pulse;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;

namespace IngameScript
{
    partial class Program : MyGridProgram, ITemplateProgram
    {
        public void Init()
        {
            Runtime.UpdateFrequency = UpdateFrequency.Update10;
        }

        public void Execute(string argument, UpdateType updateSource)
        {
        } 
    }
}
