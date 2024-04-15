using Sandbox.ModAPI.Ingame;

namespace IngameScript.Logger
{

    public sealed class PanelLogger : ILogger
    {
        private IMyTextPanel _panel;

        public PanelLogger(IMyTextPanel panel)
        {
            _panel = panel;
        }

        public void Add(string str, object obj = null)
        {
            if (str == string.Empty || str == null)
            {
                return;
            }

            _panel.WriteText(str, true);
        }

        public void Clear()
        {
            _panel.WriteText(string.Empty);
        }
    }
}

