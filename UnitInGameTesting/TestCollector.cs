using IngameScript.UnitTesting;
using System.Collections.Generic;

namespace IngameScript
{
    class TestCollector
    {
        public List<BaseTestClass> classes = new List<BaseTestClass>();

        public void Add(BaseTestClass testClass)
        {
            classes.Add(testClass);
        }

        public List<Test> GetTests()
        {
            var list = new List<Test>();

            foreach (var item in classes)
            {
                list.AddArray(item.tests.ToArray());
            }

            return list;
        }
    }
}
