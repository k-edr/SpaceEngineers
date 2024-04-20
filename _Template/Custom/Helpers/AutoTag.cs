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
        public static void AddToBlockCustomeName(string tag, IMyTerminalBlock block)
        {
            if (!HaveTag(tag, block))
            {
                block.CustomName = string.Concat(tag, block.CustomName);
            }
        }

        public static void AddToBlocksCustomeName(string tag, ICollection<IMyTerminalBlock> blocks)
        {
            foreach (var block in blocks)
            {
                AddToBlockCustomeName(tag, block);
            }
        }

        private static bool HaveTag(string tag, IMyTerminalBlock block)
        {
            return block.CustomName.Contains(tag);
        }
    }
}
