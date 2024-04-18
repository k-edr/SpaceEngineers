using System.Collections.Generic;
using System.Linq;
using IngameScript.Logger;
using Sandbox.ModAPI.Ingame;

namespace IngameScript
{
    public class Lidar
    {
        private List<IMyCameraBlock> cameras = null;

        private int _scanDistanceLimit = 0;

        private int indexiter = 0;

        private ILogger _logger;
        public Lidar(ILogger logger,IReadOnlyCollection<IMyCameraBlock> cameras, int scanDistanceLimit)
        {
            this.cameras = cameras.ToList();

            _scanDistanceLimit = scanDistanceLimit;

            _logger = logger;

            EnableRaycast(this.cameras);
        }

        private void EnableRaycast(List<IMyCameraBlock> collection)
        {
            foreach (var camera in collection)
            {
                camera.EnableRaycast = true;
            }

            _logger.AddLine("Raycast enabled");

            _logger.AddLine("Total enabled: " + collection.Count);
        }
        public MyDetectedEntityInfo Scan(float pitch = 0, float yaw = 0)
        {
            IMyCameraBlock camera = cameras[indexiter++];

            if (indexiter>=cameras.Count)
            {
                indexiter = 0;
            }

            return camera.Raycast(_scanDistanceLimit, pitch, yaw);
        }
    }
}
