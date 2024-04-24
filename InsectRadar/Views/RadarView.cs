using Sandbox.ModAPI.Ingame;
using System.Linq;

namespace IngameScript.Views
{
    public class RadarView
    {
        private IMyTextPanel _panel;

        public RadarView(IMyTextPanel panel)
        {
            _panel = panel;
        }

        public void Show(MyDetectedEntityInfo info)
        {
            var str = string.Empty;

            if (!info.IsEmpty())
            {
                str += $"Id: {info.EntityId}\n Size: {info.BoundingBox}\n Position: {info.Position}\n Velocity: {info.Velocity}";
            }
            else
            {
                str += "Nothing detected";
            }

            _panel.WriteText(str);
        }
    }
}
