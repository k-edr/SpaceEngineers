using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript.Torpedo.Speed
{
    public abstract class BaseSpeedController : IControllableSpeed
    {
        protected List<IMyThrust> _forwardThrusters;

        protected BaseSpeedController()
        {
            _forwardThrusters = new List<IMyThrust>();
        }

        public abstract void ControllSpeed<T>(T val = null) where T: class;

        public void Add(IMyThrust thruster)
        {
            _forwardThrusters.Add(thruster);
        }

        public void Set(ICollection<IMyThrust> thrusters)
        {
            _forwardThrusters = (List<IMyThrust>)thrusters;
        }

        public bool Contains(IMyThrust thruster)
        {
            return _forwardThrusters.Contains(thruster);
        }

        public void Remove(IMyThrust thruster)
        {
            _forwardThrusters.Remove(thruster);
        }

        public abstract void ControllSpeed();
    }
}