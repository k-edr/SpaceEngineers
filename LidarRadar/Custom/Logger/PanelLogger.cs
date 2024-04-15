using IngameScript.Stuff.Logger;
using Sandbox.ModAPI.Ingame;

namespace IngameScript.Logger
{

    sealed class PanelLogger : BaseLogger
    {
        private readonly IMyTextPanel _panel;
 
        /// <summary>
        /// If isNeedLogger = false, panel can be null
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="isNeedLogger"></param>
        public PanelLogger(IMyTextPanel panel, bool needUseLogger = true):base(needUseLogger)
        {
            if (needUseLogger)
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

            if (_needUseLogger)
            {
                _panel.WriteText(str, true);
            }
        }

        public void Clear()
        {
            if (_needUseLogger)
            {
                _panel.WriteText(string.Empty); 
            }
        }
    }
}

