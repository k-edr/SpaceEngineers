using IngameScript.Logger;
using Sandbox.Game.Entities.Interfaces;
using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript.Torpedo.Speed
{
    public class AtmoSpeedController:BaseSpeedController
    {
        private int _minSpeed;

        private int _maxSpeed;

        private IMyShipController _myShip;

        private ILogger _logger;

        public AtmoSpeedController(ILogger logger ,IMyShipController myShip, int minSpeed, int maxSpeed):base()
        {
            _myShip = myShip;
            _minSpeed = minSpeed;
            _maxSpeed = maxSpeed;
        }

        public override void ControllSpeed<T>(T val = null) 
        {
            ControllSpeed();
        }

        public override void ControllSpeed()
        {
            double speed = _myShip.GetShipSpeed();

            if (_myShip.GetTotalGravity().IsZero())
            {
                OnOffThrusters(speed < _minSpeed, _forwardThrusters);
            }
            else
            {
                OnOffThrusters(speed < _maxSpeed, _forwardThrusters);
            }
        }

        private void OnOffThrusters(bool onOff, ICollection<IMyThrust> thrusts)
        {
            if (thrusts.FirstOrDefault().Enabled == onOff)
            {
                return;
            }
            else
            {
                foreach (var thrust in thrusts)
                {
                    thrust.Enabled = onOff;
                }

                _logger.Add($"\n Switched forward thrusters to {onOff}");
                _logger.Add($"\n Total switched: {thrusts.Count}");
            }
        }


    }
}
