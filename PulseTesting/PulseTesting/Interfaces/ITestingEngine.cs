using IngameScript.PulseTesting.Models;

namespace IngameScript.PulseTesting.Interfaces
{
    public interface ITestingEngine
    {
        TestResult[] ExecuteAll();

        bool TryExecuteNext(out TestResult result);

        void Reset();
    }
}
