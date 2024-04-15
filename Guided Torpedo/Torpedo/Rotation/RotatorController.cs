using IngameScript.Logger;
using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRageMath;

namespace IngameScript.Torpedo.Rotation
{
    public class RotatorController
    {
        private IMyShipController _shipController;

        private List<IMyGyro> _gyros;

        private ILogger _logger;

        public RotatorController(ILogger logger,IMyShipController shipController)
        {
            _logger = logger;
            _shipController = shipController;
            _gyros = new List<IMyGyro>();
        }

        public void Add(IMyGyro gyro)
        {
            _gyros.Add(gyro);
        }

        public void Remove(IMyGyro gyro)
        {
            _gyros.Remove(gyro);
        }

        public bool Contains(IMyGyro gyro)
        {
            return _gyros.Contains(gyro);
        }

        public void RotateTo(Vector3D target)
        {
            var settings = GetNavAngles(target);
            SetGyroOverride(true, settings*3);

            _logger.Add($"\n Set gyro settings: {settings}");
        }

        private Vector3D GetNavAngles(Vector3D target)
        {
            Vector3D center = _shipController.GetPosition();
            Vector3D forward = _shipController.WorldMatrix.Forward;
            Vector3D up = _shipController.WorldMatrix.Up;
            Vector3D left = _shipController.WorldMatrix.Left;

            var norm = Vector3D.Normalize(target - center) ;

            double pitch = Math.Acos(Vector3D.Dot(up , norm)) - (Math.PI / 2);
            double yaw = Math.Acos(Vector3D.Dot(left, norm)) - (Math.PI / 2);
            double roll = Math.Acos(Vector3D.Dot(_shipController.GetNaturalGravity(), up)) - (Math.PI / 2);

            return new Vector3D(yaw, -pitch, roll);
        }

        private void SetGyroOverride(bool overrideOnOff, Vector3D settings)
        {
            foreach (var gyro in _gyros)
            {
                gyro.GyroOverride = overrideOnOff;

                gyro.Yaw = (float)settings.GetDim(0);
                gyro.Pitch = (float)settings.GetDim(1);
                gyro.Roll = (float)settings.GetDim(2);
            }
        }
    }
}