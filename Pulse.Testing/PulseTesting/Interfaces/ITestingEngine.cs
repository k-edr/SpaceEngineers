using IngameScript.Pulse.Testing.Models;

namespace IngameScript.Pulse.Testing.Interfaces
{
    public interface ITestingEngine
    {
        TestResult[] ExecuteAll();

        bool TryExecuteNext(out TestResult result);

        void Reset();
    }
}
