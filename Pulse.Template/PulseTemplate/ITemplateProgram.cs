using Sandbox.ModAPI.Ingame;

namespace IngameScript.Pulse.Template
{
    public interface ITemplateProgram
    {
        void Init();

        void Execute(string argument, UpdateType updateSource);
    }

}