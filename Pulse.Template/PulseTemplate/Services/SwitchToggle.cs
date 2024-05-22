using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript.Pulse.Template.Services
{
    public static class SwitchToggle
    {
        public static void SetTo(bool enabled, params IMyFunctionalBlock[] blocks)
        {
            foreach (var block in blocks)
            {
                if(block != null)
                {
                    block.Enabled = enabled;
                }
            }
        }
    }
}
