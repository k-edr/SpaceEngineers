using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;
using System.Text;

namespace IngameScript.Views
{
    public class MultiTargetRadarView
    {
        private IMyTextPanel _textPanel;

        public MultiTargetRadarView(IMyTextPanel textPanel)
        {
            _textPanel = textPanel;
        }

        public void Show(ICollection<MyDetectedEntityInfo> entities) 
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var entity in entities)
            {               
                stringBuilder.AppendLine($"Id: {entity.EntityId}\n Size: {entity.BoundingBox}\n Position: {entity.Position}\n Velocity: {entity.Velocity}");
            }

            _textPanel.WriteText(stringBuilder.ToString());
        }
    }
}
