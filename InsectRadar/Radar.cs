using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;

namespace IngameScript
{
    public class Radar
    {
        private ScanPlot _plot;

        private IMyGridProgramRuntimeInfo _runtimeInfo;

        public MyDetectedEntityInfo _lastDetectedEntity { get; protected set; } = default(MyDetectedEntityInfo);

        public bool IsDetectedEntity => _lastDetectedEntity.EntityId != 0;

        public Radar(ScanPlot plot, IMyGridProgramRuntimeInfo runtimeInfo)
        {
            if (plot == null) throw new ArgumentNullException("Argument cannot be null", nameof(plot));
            if (runtimeInfo == null) throw new ArgumentNullException("Argument cannot be null", nameof(runtimeInfo));

            _plot = plot;
            _runtimeInfo = runtimeInfo;
        }

        public void TryLock(int scanDistanceLimit = 20000)
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

        public void ResetRadar()
        {
            _lastDetectedEntity = default(MyDetectedEntityInfo);
        }
    }
}
