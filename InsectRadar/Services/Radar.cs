using Sandbox.ModAPI.Ingame;
using System;

namespace IngameScript.Services
{

    public class Radar
    {
        protected ScanPlot _plot;

        protected IMyGridProgramRuntimeInfo _runtimeInfo;

        public MyDetectedEntityInfo _lastDetectedEntity { get; protected set; } = default(MyDetectedEntityInfo);

        private bool IsDetectedEntity => _lastDetectedEntity.EntityId != 0;

        public Radar(ScanPlot plot, IMyGridProgramRuntimeInfo runtimeInfo)
        {
            if (plot == null) throw new ArgumentNullException("Argument cannot be null", nameof(plot));
            if (runtimeInfo == null) throw new ArgumentNullException("Argument cannot be null", nameof(runtimeInfo));

            _plot = plot;
            _runtimeInfo = runtimeInfo;
        }

        public virtual void TryLock(int scanDistanceLimit = 20000)
        {
            if(!IsDetectedEntity)
            {
                var camera = _plot.GetAvailableCamera(scanDistanceLimit);

                if(camera != null)
                {
                    _lastDetectedEntity = camera.Raycast(scanDistanceLimit);
                }
            }
            else
            {
                var currentTargetPos = _lastDetectedEntity.Position + _lastDetectedEntity.Velocity * (float)_runtimeInfo.TimeSinceLastRun.TotalSeconds;

                var camera = _plot.GetAvailableCamera(currentTargetPos);

                _lastDetectedEntity = camera.Raycast(currentTargetPos);
            }
        }

        public virtual void ResetRadar()
        {
            _lastDetectedEntity = default(MyDetectedEntityInfo);
        }
    }
}
