using Sandbox.ModAPI.Ingame;

namespace IngameScript
{
    interface ITemplateProgram
    {
        void Init();

        void Execute(string argument, UpdateType updateSource);    
    }

}