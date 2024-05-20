using IngameScript.PulseTesting.Interfaces;
using IngameScript.PulseTesting.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace IngameScript.PulseTesting.Services
{
    public class TestingEngine:ITestingEngine
    {
        public const string VERSION = "0.1.0";

        private List<TestClass> _testClasses;

        private List<TestMethod> _methods = new List<TestMethod>();

        private int _index = 0;

        public TestingEngine(params TestClass[] testClasses)
        {
            _testClasses = new List<TestClass>(testClasses);

            foreach (var testClass in _testClasses)
            {
                _methods.AddRange(testClass.Methods);
            }
        }

        public virtual TestResult[] ExecuteAll() 
        {
            List<TestResult> testResults = new List<TestResult>();

            foreach (var method in _methods)
            {
                testResults.Add(Execute(method));
            }

            return testResults.ToArray();
        }

        public void Reset()
        {
            _index = 0;
        }

        public virtual bool TryExecuteNext(out TestResult result) 
        {
            result = null;

            if(_index > _methods.Count) return false;
            else
            {
                result = Execute(_methods[_index++]);

                return true;
            }
        }

        protected virtual TestResult Execute(TestMethod method)
        {
            TestResult result = new TestResult();

            result.MethodName = method.MethodName;
            result.ClassName = method.ClassName;
            result.Status = true;
            result.Message = string.Empty;
            result.ExecuteTime = -1;

            DateTime start = DateTime.Now;
            try
            {
                method.Fixture.Invoke();
            }
            catch(Exception ex)
            {
                result.Message += ex.ToString();
                result.Status = false;
            }
            finally
            {
                result.ExecuteTime = (DateTime.Now - start).Ticks;
            }

            return result;
        }
    }
}
