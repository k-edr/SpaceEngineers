using IngameScript.Pulse.Testing;
using IngameScript.Pulse.Testing.Models;

namespace IngameScript.Pulse.Testing.Interfaces
{
    public interface ITestReportMaker
    {
        string Make(string resultSeparator,string startReportFrom="", string endReportWith="", params TestResult[] results);
    }
}
