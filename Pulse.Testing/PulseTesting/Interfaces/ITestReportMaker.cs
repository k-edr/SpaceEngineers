using IngameScript.PulseTesting;
using IngameScript.PulseTesting.Models;

namespace IngameScript.PulseTesting.Interfaces
{
    public interface ITestReportMaker
    {
        string Make(string resultSeparator,string startReportFrom="", string endReportWith="", params TestResult[] results);
    }
}
