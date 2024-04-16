using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript.Custom.Heplers
{
    public class AutoTag
    {
        public static void AddTagToBlockCustomeName(string tag, IMyTerminalBlock block)
        {
            block.CustomName = string.Concat(tag, block.CustomName);
        }

        public static void AddTagToBlocksCustomeName(string tag, ICollection<IMyTerminalBlock> blocks)
        {
            foreach (var block in blocks)
            {
                AddTagToBlockCustomeName(tag, block);
            }
        }
    }
}
