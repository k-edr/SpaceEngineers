using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript.MyGridSystem
{
    public class MyGrid
    {
        public List<IMyTerminalBlock> GridBlocks { get; private set; }

        public MyGrid(List<IMyTerminalBlock> gridBlocks)
        {
            GridBlocks = gridBlocks;
        }

        public MyGrid(IMyBlockGroup blockGroup)
        {
            GridBlocks = new List<IMyTerminalBlock>();

            blockGroup.GetBlocks(GridBlocks);
        }

        public IMyTerminalBlock GetBlockWithName(string name)
        {
            return GridBlocks.FirstOrDefault(block => block.CustomName == name);
        }

        public IMyTerminalBlock GetBlockWithId(long id)
        {
            return GridBlocks.FirstOrDefault(block => block.EntityId == id);
        }

        public void GetBlocksOfType<T>(List<T> list)
        {
            list = GridBlocks.Select(x => x).Where(x => x.GetType() == typeof(T)).ToList() as List<T>;
        }
    }
}
