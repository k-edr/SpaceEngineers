using Sandbox.ModAPI.Ingame;
using System;
using VRageMath;

namespace IngameScript
{
    class GPSRotatorController
    {
        private GyroModel _gyroModel = null;

        //private GPSModel _gpsModel;

        public IMyShipController _shipController = null;

        public GPSRotatorController(GyroModel gyroModel, IMyShipController shipController)
        {
            _gyroModel = gyroModel;
            _shipController = shipController;
        }

        public Vector3D GetNavAngles(Vector3D target)
        {
            Vector3D center = _shipController.GetPosition();
            Vector3D forward = _shipController.WorldMatrix.Forward;
            Vector3D up = _shipController.WorldMatrix.Up;
            Vector3D left = _shipController.WorldMatrix.Left;

            var norm = Vector3D.Normalize(target - center);

            double pitch = Math.Acos(Vector3D.Dot(up, norm)) - (Math.PI / 2);
            double yaw = Math.Acos(Vector3D.Dot(left, norm)) - (Math.PI / 2);
            double roll = 0;

            return new Vector3D(yaw, -pitch, roll);
        }
        public void SetGyroOverride(bool overrideOnOff, Vector3D settings, float power)
        {
            _gyroModel.Gyro.GyroOverride = overrideOnOff;

            _gyroModel.Yaw = (float)settings.GetDim(0);
            _gyroModel.Pitch = (float)settings.GetDim(1);
            _gyroModel.Roll = (float)settings.GetDim(2);
        }
    }
}