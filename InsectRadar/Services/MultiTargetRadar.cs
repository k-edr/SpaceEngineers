using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;
using System.Linq;
using VRage.Input;
using VRageMath;

namespace IngameScript.Services
{
    public class MultiTargetRadar : Radar
    {
        private Dictionary<long,MyDetectedEntityInfo> _targets = new Dictionary<long,MyDetectedEntityInfo>();

        private int _currentTargetIndex = 0;

        private List<long> _keys = new List<long>();
        public MyDetectedEntityInfo[] GetTargets => _targets.Values.ToArray();

        public MultiTargetRadar(ScanPlot plot, IMyGridProgramRuntimeInfo runtimeInfo) : base(plot, runtimeInfo)
        {
        }

        //TODO: create new collection only for keys. Do not create new list every time
        public override void TryLock(int scanDistanceLimit = 20000)
        {
            if(_currentTargetIndex >= _keys.Count)
            {
                _currentTargetIndex = 0;
            }
            if(_keys.Count == 0)
            {
                return;
            }

            Vector3D currentTargetPos = _targets[_keys[_currentTargetIndex]].Position + _targets[_keys[_currentTargetIndex]].Velocity * (float)_runtimeInfo.TimeSinceLastRun.TotalSeconds;

            var camera = _plot.GetAvailableCamera(currentTargetPos);

            _targets[_keys[_currentTargetIndex]] = camera.Raycast(currentTargetPos);

            _currentTargetIndex++;
        }

        public void TryLockNewTarget(ref bool isNewTargetLocked, int scanDistanceLimit = 20000)
        {
            isNewTargetLocked = false;

            var camera = _plot.GetAvailableCamera(scanDistanceLimit);

            if (camera != null)
            {
                var temp = camera.Raycast(scanDistanceLimit);

                if (!temp.IsEmpty())
                {
                    if (!_targets.ContainsKey(temp.EntityId))
                    {
                        _targets.Add(temp.EntityId, temp);
                        _keys.Add(temp.EntityId);
                        isNewTargetLocked = true;
                    }
                }
            }
        }

        public override void ResetRadar()
        {
            _targets.Clear();
            _keys.Clear();
        }
    }
}
