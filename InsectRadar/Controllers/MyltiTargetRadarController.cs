using IngameScript.Models;
using IngameScript.Views;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IngameScript.Controllers
{
    public class MyltiTargetRadarController
    {
        private MultiTargetRadarModel _model;

        private MultiTargetRadarView _view;

        public MyltiTargetRadarController(MultiTargetRadarModel model, MultiTargetRadarView view)
        {
            _model = model;
            _view = view;
        }

        public void TryLock(int distance=20000)=>_model.Radar.TryLock(distance);

        public void Show() => _view.Show(_model.Radar.GetTargets);

        public void TryLockNewTarget(ref bool isNewTargetLocked, int scanDistanceLimit = 20000)=>_model.Radar.TryLockNewTarget(ref isNewTargetLocked, scanDistanceLimit);

        public void ResetRadar() => _model.Radar.ResetRadar();

    }
}
