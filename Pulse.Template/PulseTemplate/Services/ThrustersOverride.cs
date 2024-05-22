using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript.Pulse.Template.Services
{
    public static class ThrustersOverride
    {
        //velocity: -1 means max possible for block
        public static void SetTo(float velocity, params IMyThrust[] thrusters)
        {
            if(velocity < -1) throw new ArgumentException("Velocity can't be less than -1",nameof(velocity));

            foreach (var thruster in thrusters)
            {
                if (thruster != null)
                {
                    if (velocity == -1)
                    {
                        thruster.ThrustOverride = thruster.MaxThrust;
                    }
                    else
                    {
                        thruster.ThrustOverride = velocity;
                    }
                }
            }
        }
    }
}
