using SpaceEngineers.Game.ModAPI.Ingame;

namespace IngameScript
{
    class TorpedoModel
    {
        public string Tag;
        
        public IMyTimerBlock LaunchTimer { get; set; }

        public GPSModel Target { get; set; }

    }
}

