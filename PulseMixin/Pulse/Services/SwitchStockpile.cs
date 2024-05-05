using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript.IngameScript.Pulse.Services
{
    public static class SwitchStockpile
    {
        public static void SetTo(bool enabled, params IMyGasTank[] tanks)
        {
            foreach (var tank in tanks)
            {
                if (tank != null)
                {
                    tank.Enabled = enabled;
                }
            }
        }
    }
}
