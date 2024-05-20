using IngameScript.PulseTesting.Models;

namespace IngameScript.PulseTesting.Interfaces
{
    public interface ITestReportMaker
    {
        string Make(string resultSeparator, params TestResult[] results);
    }
}
