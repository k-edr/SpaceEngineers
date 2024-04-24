using IngameScript.Logger;
using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using VRageMath;

namespace IngameScript.Services
{
    public class ScanPlot
    {
        private ILogger Logger;

        private readonly List<IMyCameraBlock> _cameras;

        public ScanPlot(ILogger logger, List<IMyCameraBlock> cameras)
        {
            if(logger == null) throw new ArgumentNullException("Argument cannot be null", nameof(logger));
            if(cameras == null) throw new ArgumentNullException("Argument cannot be null", nameof(cameras));

            Logger = logger;
            _cameras = cameras;

            SwitchRaycast(true, _cameras);
        }

        public double GetTotalAvailableRange
        {
            get
            {
                double totalRange = 0;
                foreach (var camera in _cameras)
                {
                    totalRange += camera.AvailableScanRange;
                }

                return totalRange;
            }
        }

        public IMyCameraBlock GetAvailableCamera(Vector3D target)
        {
            foreach (var camera in _cameras)
            {
                if (camera.CanScan(target))
                {
                    return camera;
                }
            }

            return null;
        }

        public IMyCameraBlock GetAvailableCamera(int distance)
        {
            foreach (var camera in _cameras)
            {
                if (camera.CanScan(distance))
                {
                    return camera;
                }
            }

            return null;
        }

        private void SwitchRaycast(bool status, List<IMyCameraBlock> cameras)
        {
            foreach (var camera in cameras)
            {
                camera.EnableRaycast = status;
            }

            Logger.AddLine($"Switched {cameras.Count} cameras Raycast to {(status ? "On" : "Off")}");
        }
    }
}
