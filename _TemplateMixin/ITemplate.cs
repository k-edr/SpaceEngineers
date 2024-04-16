using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Text;
using VRageRender.Messages;

namespace IngameScript.Custom
{
    public interface ITemplate
    {
        void Init();

        void Execute(string argument, UpdateType updateSource);
    }
}
