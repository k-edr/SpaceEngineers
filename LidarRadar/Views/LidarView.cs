using Sandbox.ModAPI.Ingame;

namespace IngameScript
{
    public class LidarView
    {
        private IMyTextPanel _textPanel;

        public LidarView(IMyTextPanel textPanel)
        {
            _textPanel = textPanel;
        }

        public void Update(string scanResult)
        {
           _textPanel.WriteText(scanResult);
        }
    }
}
