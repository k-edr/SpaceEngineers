using Sandbox.ModAPI.Ingame;

namespace IngameScript
{
    class GyroModel
    {
        public IMyGyro Gyro { get; set; }   

        public float Yaw { get { return Gyro.Yaw; } set { Gyro.Yaw = value; } }
        
        public float Pitch { get { return Gyro.Pitch; } set { Gyro.Pitch = value; } }
        
        public float Roll { get { return Gyro.Roll; } set { Gyro.Roll = value; } }
    }
}