﻿using IngameScript.PulseTesting;
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
        private string _startReportFrom = string.Empty;

        private string _endReportWith = string.Empty;

        public TestReportMaker(string startReportFrom = "", string endReportWith="")
        {
            _startReportFrom = startReportFrom;
            _endReportWith = endReportWith;
        }


        //TODO: extract base result
        protected virtual string FormBadResult(TestResult result)
        {
            return $"\t Method name:{result.MethodName},\n\t Class name:{result.ClassName},\n\t Test status:{result.Status},\n\tExecuted for: {DateTime.FromBinary(result.ExecuteTime).Millisecond}ms,\n\tMessage: {result.Message}";
        }

        protected virtual string FormGoodResult(TestResult result)
        {
            return $"\t Method name:{result.MethodName},\n\t Class name:{result.ClassName},\n\t Test status:{result.Status},\n\tExecuted for: {DateTime.FromBinary(result.ExecuteTime).Millisecond}ms";
        }

        public virtual string Make(string resultSeparator, params TestResult[] results)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(_startReportFrom);

            sb.AppendLine(FormStatistics(results));

            sb.AppendLine();

            foreach (var testResult in results)
            {

                sb.AppendLine((testResult.Status ? FormGoodResult(testResult) : FormBadResult(testResult)) + resultSeparator);
            }

            sb.AppendLine(_endReportWith);

            return sb.ToString();
        }

        protected string FormStatistics(TestResult[] results)
        {
            int passedTests = results.Where(r => r.Status == true).Count();

            return $"\t Total tested: {results.Length}\n\t Tests passed: {passedTests}\n\t Tests failed: {results.Length - passedTests}";
        }

    }
}