using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngameScript.UnitTesting
{
    public class TestExecutor
    {
        private Queue<Test> tests = new Queue<Test>();

        private Action<string> _echo;
        public List<Test> TestsResult { get; private set; } = new List<Test>();
        public TestExecutor(ICollection<Test> tests, Action<string> echo)
        {
            this.tests = new Queue<Test>(tests);
            _echo = echo;
        }

        public void ExecuteNext()
        {
            if(tests.Count == 0)
            {
                return;
            }

            var test = tests.Dequeue();

            test.Execute();

            TestsResult.Add(test);

        }
    }
}

