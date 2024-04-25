using IngameScript.UnitTesting;
using System;
using System.Collections.Generic;

namespace IngameScript
{
    abstract class BaseTestClass
    {
        public List<Test> tests { get; private set; } = new List<Test>();

        public void AddTest(Action action)
        {
            tests.Add(new Test(action, action.Method.Name));
        }
    }
}
