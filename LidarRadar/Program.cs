using System;
using System.Collections.Generic;
using System.Linq;
using IngameScript.Const;
using IngameScript.Custom;
using IngameScript.Logger;
using IngameScript.MyGridSystem;
using Sandbox.ModAPI.Ingame;
using VRageMath;

namespace IngameScript
{
    
    class Lidar
    {
        private List<IMyCameraBlock> cameras = null;

        private int _scanDistanceLimit = 0;

        private IEnumerator<IMyCameraBlock> _enumerator;
        public Lidar(IReadOnlyCollection<IMyCameraBlock> cameras, int scanDistanceLimit)
        {
            this.cameras = cameras.ToList();

            _scanDistanceLimit = scanDistanceLimit;

            _enumerator = cameras.GetEnumerator();

            EnableRaycast(this.cameras);
        }

        private void EnableRaycast(ICollection<IMyCameraBlock> collection)
        {
            foreach (var camera in collection)
            {
                camera.EnableRaycast = true;
            }
        }
        public MyDetectedEntityInfo Scan(float pitch = 0, float yaw = 0)
        {
            IMyCameraBlock camera = _enumerator.Current;

            if (_enumerator.MoveNext())
            {
                _enumerator.Reset();
            }

            return camera.Raycast(_scanDistanceLimit, pitch, yaw);
        }
    }
   
    partial class Program : MyGridProgram, ITemplate
    {
        public void Init()
        {
            
        }

        public bool tryLock = false;
        public void Execute(string argument, UpdateType updateSource)
        {
            if(updateSource == UpdateType.Trigger || updateSource == UpdateType.Terminal)
            {
                switch (argument)
                {
                    case "TryLock":

                        tryLock = true;

                        break;
                    case "StopLock":

                        tryLock = false;

                        break;
                    default:

                        Echo("Unknown argument: " + argument);

                        Logger.AddLine("Unknown argument: " + argument);

                        return;
                }

                Logger.AddLine("Executed command: " + argument);
            }
            else
            {
                if (tryLock)
                {

                }
            }      
        }
    }
}
