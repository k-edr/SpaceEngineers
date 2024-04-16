using IngameScript.Stuff.Logger;
using Sandbox.ModAPI.Ingame;

namespace IngameScript.Logger
{

    sealed class PanelLogger : BaseLogger
    {
        private readonly IMyTextPanel _panel;

        /// <summary>
        /// If needUseLogger = false, panel can be null
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="needLogger"></param>
        public PanelLogger(IMyTextPanel panel, bool needLogger = true):base(needLogger)
        {
            if (needLogger)
            {
                _panel = panel;
            }
        }

        public override void Add(string str, object obj = null)
        {
            if (str == string.Empty || str == null)
            {
                return;
            }

            if (_needLogger)
            {
                _panel.WriteText(str, true);
            }
        }

        public void Clear()
        {
            if (_needLogger)
            {
                _panel.WriteText(string.Empty); 
            }
        }
    }
}

