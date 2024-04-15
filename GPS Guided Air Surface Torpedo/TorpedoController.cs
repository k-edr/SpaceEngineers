namespace IngameScript
{
    class TorpedoController
    {
        public TorpedoModel Model {  get; set; }

        public GPSRotatorController Rotator { get; set; }

        public TorpedoController()
        {
        }

        public void Launch()
        {
            if(Model.Target == null)
            {
                return;
            }

            Model.LaunchTimer.Trigger();
        }

        public void SetCoordinats(GPSModel gps)
        {
            if (gps == null)
            {
                return;
            }

            Model.Target = gps;
        }

        
    }
}

