using Sandbox.ModAPI.Ingame;

namespace IngameScript.IngameScript.Pulse.Services
{
    public static class AutoTag
    {
        public static void Add(string tag, params IMyTerminalBlock[] blocks)
        {
            foreach (var block in blocks)
            {
                if (block.CustomName.Contains(tag) || block == null) continue;

                block.CustomName = tag + block.CustomName;
            }
        }

        public static void Remove(string tag, params IMyTerminalBlock[] blocks)
        {
            foreach (var block in blocks)
            {
                if (!block.CustomName.Contains(tag) || block == null) continue;

                block.CustomName = block.CustomName.Replace(tag, "");
            }
        }
    }
}
