using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript
{
    internal class SpeedController
    {
        private Model model;

        public SpeedController(IMyThrust thrust, int low, int top)
        {
            model = new Model() { Front = thrust, lowBound = low, topBound = top };
        }

        class Model
        {
            public IMyThrust Front;

            public int lowBound = 300;

            public int topBound = 450;
        }

        public void ControllThruster(float speed)
        {
            if(speed >= model.topBound)
            {
                model.Front.Enabled = false;
            }
            else
            {
                model.Front.Enabled = true;
            }
        }

    }
}
