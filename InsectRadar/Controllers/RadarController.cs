using IngameScript.Models;
using IngameScript.Views;

namespace IngameScript.Controllers
{
    public class RadarController
    {
        private RadarModel _model;

        private RadarView _view;

        public RadarController(RadarModel model, RadarView view)
        {
            _model = model;
            _view = view;
        }

        public void TryLock(int distance = 20000)
        {
            _model.Radar.TryLock(distance);
        }

        public void Show()
        {
            _view.Show(_model.Radar._lastDetectedEntity);
        }

        public void ResetRadar()
        {
            _model.Radar.ResetRadar();
        }
    }
}
