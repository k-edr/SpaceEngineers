using IngameScript.PulseTesting;
using IngameScript.PulseTesting.Interfaces;
using IngameScript.PulseTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript.PulseTesting.Services
{
    public class TestReportMaker : ITestReportMaker
    {       

        //TODO: extract base result
        protected virtual string FormBadResult(TestResult result)
        {
            return $"\t Method name:{result.MethodName},\n\t Class name:{result.ClassName},\n\t Test status:{result.Status},\n\tExecuted for: {DateTime.FromBinary(result.ExecuteTime).Millisecond}ms,\n\tMessage: {result.Message}";
        }

        protected virtual string FormGoodResult(TestResult result)
        {
            return $"\t Method name:{result.MethodName},\n\t Class name:{result.ClassName},\n\t Test status:{result.Status},\n\tExecuted for: {DateTime.FromBinary(result.ExecuteTime).Millisecond}ms";
        }

        public virtual string Make(string resultSeparator, string startReportFrom = "", string endReportWith = "", params TestResult[] results)
        {
            StringBuilder sb = new StringBuilder();

            if (!startReportFrom.Equals(string.Empty))
            {
                sb.AppendLine(startReportFrom);
            }

            sb.AppendLine(FormStatistics(results));

            sb.AppendLine();

            foreach (var testResult in results)
            {

                sb.AppendLine((testResult.Status ? FormGoodResult(testResult) : FormBadResult(testResult)) + resultSeparator);
            }

            if (!endReportWith.Equals(string.Empty))
            {
                sb.AppendLine(endReportWith);
            }

            return sb.ToString();
        }

        protected string FormStatistics(TestResult[] results)
        {
            int passedTests = results.Where(r => r.Status == true).Count();

            return $"\t Total tested: {results.Length}\n\t Tests passed: {passedTests}\n\t Tests failed: {results.Length - passedTests}";
        }

    }
}
