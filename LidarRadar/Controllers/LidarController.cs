using Sandbox.ModAPI.Ingame;

namespace IngameScript
{
    public class LidarController
    {
        private LidarModel _lidarModel;

        private LidarView _lidarView;

        private MyDetectedEntityInfo _lastScan = default(MyDetectedEntityInfo);

        public LidarController(LidarModel lidarModel, LidarView lidarView)
        {
            _lidarModel = lidarModel;
            _lidarView = lidarView;
        }

        public MyDetectedEntityInfo Scan(float pitch = 0, float yaw = 0)
        {
            _lastScan = _lidarModel.Lidar.Scan(pitch, yaw);
            return _lastScan;
        }

        public void UpdateView()
        {
            string str = PrepareLastScan(_lastScan);

            _lidarView.Update(str);
        }

        private static string PrepareLastScan(MyDetectedEntityInfo lastScan)
        {
            string str = string.Empty;

            if (!lastScan.IsEmpty())
            {
                str += $"EntityPos: {lastScan.Position} Velocity: {lastScan.Velocity}";
            }
            else
            {
                str += "Nothing detected";
            }

            return str;
        }
    }
}
