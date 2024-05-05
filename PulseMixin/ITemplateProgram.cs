using Sandbox.ModAPI.Ingame;

namespace IngameScript
{
    public interface ITemplateProgram
    {
        void Init();

        void Execute(string argument, UpdateType updateSource);    
    }

}