using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript.UnitTesting
{
    public class Test
    {
        private Action _method;

        private string _methodName;

        public AssertionSummary _summary = new AssertionSummary();

        public TestStatus Status { get; private set; } = TestStatus.Not_Executed;
        public Test(Action method, string methodName)
        {
            _method = method;
            _methodName = methodName;
        }

        public void Execute()
        {
            long start = DateTime.Now.Ticks;

            _summary.AddLine("Test name: " + _methodName);

            try
            {
                _method.Invoke();
            }
            catch (Exception e)
            {
                _summary.AddLine(e.ToString());

                Status = TestStatus.Failed;

                return;
            }
            long stop = DateTime.Now.Ticks;

            _summary.AddLine("Test passed");
            _summary.AddLine($"Executed for {new DateTime(stop - start).Millisecond} ms");
            Status = TestStatus.Passed;
        }
    }
}
