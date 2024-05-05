using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript.IngameScript.Pulse.Loggers
{
    public class PanelLogger : ILogger
    {
        private IMyTextPanel _panel;

        public PanelLogger(IMyTextPanel panel)
        {
            if(panel == null) throw new ArgumentNullException(nameof(panel));

            _panel = panel;

            _panel.ContentType = VRage.Game.GUI.TextPanel.ContentType.TEXT_AND_IMAGE;
        }

        public void Add(string message, object data = null)
        {
            if (message == string.Empty || message == null) return;

            _panel.WriteText(message, true);
        }

        public void AddLine(string message, object data = null) => Add(message + '\n', data);

        public void Clear() => _panel.WriteText(string.Empty);
    }
}
