using IngameScript.PulseTesting.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngameScript.PulseTesting.Models
{
    public class TestMethod : ITest
    {
        public string ClassName { get; }

        public string MethodName { get; }

        public Action Fixture { get; }

        public TestMethod() { }

        public TestMethod(string methodName, string className, Action method)
        {
            ClassName = className;
            MethodName = methodName;
            Fixture = method;
        }
    }
}
