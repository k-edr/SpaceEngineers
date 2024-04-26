using IngameScript.Custom;
using Sandbox.ModAPI.Ingame;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IngameScript
{
    class TestBuilder
    {
        private readonly Test _test = new Test();

        public TestBuilder AddMethod(Action method)
        {
            if (method == null) throw new ArgumentException("Argument can't be null", nameof(method));

            _test.Method = method;

            return this;
        }

        public TestBuilder AddName(string name)
        {
            if (name == null || name == string.Empty) throw new ArgumentException("Argument can't be null or empty", nameof(name));

            _test.Name = name;

            return this;
        }

        public Test Create() => _test;
    }

    enum TestStatus
    {
        Not_Executed,
        Failed,
        Passed
    }

    class Test
    {

        public Action Method;

        public string Name;
    }

    public abstract class BaseTestClass
    {
        private List<Action> actions = new List<Action>();

        protected internal void AddMethod(Action action) => actions.Add(action);

        internal Action[] GetMethods() => actions.ToArray();
    }

    class TestClassContainer
    {
        private List<BaseTestClass> classes = new List<BaseTestClass>();

        public void Add(BaseTestClass testClass)
        {
            NullThrow(testClass);

            classes.Add(testClass);
        }

        public bool Remove(BaseTestClass testClass)
        {
            NullThrow(testClass);

            return classes.Remove(testClass);
        }

        public bool Contains(BaseTestClass testClass)
        {
            NullThrow(testClass);

            return classes.Contains(testClass);
        }

        public BaseTestClass[] Get() => classes.ToArray();

        private static void NullThrow(BaseTestClass testClass)
        {
            if (testClass == null) throw new ArgumentException("Argument can't be null", nameof(testClass));
        }
    }

    class ExecuteResult
    {
        public Test Test { get; set; }

        public TestStatus Status { get; set; } = TestStatus.Not_Executed;

        public Exception Exception { get; set; } = null;
    }

    class TestExecutor
    {
        public virtual ExecuteResult[] Execute(params Test[] tests)
        {
            var results = new ExecuteResult[tests.Length];
            int index = 0;

            foreach (var test in tests)
            {
                try
                {
                    test.Method.Invoke();
                }
                catch (Exception ex)
                {
                    results[index++] = new ExecuteResult()
                    {
                        Test = test,
                        Status = TestStatus.Failed,
                        Exception = ex
                    };

                    continue;
                }

                results[index++] = new ExecuteResult()
                {
                    Test = test,
                    Status = TestStatus.Passed,
                };
            }

            return results;
        }
    }

    class Summary
    {
        public string Text { get; set; }
    }

    class SummaryBuilder
    {
        private readonly Summary _summary = new Summary();

        private readonly StringBuilder _sb = new StringBuilder();

        public SummaryBuilder AddName(string name)
        {
            if (name == null) throw new ArgumentException("Argument can't be null", nameof(name));

            _sb.AppendLine("Test name:" + name);

            return this;
        }

        public SummaryBuilder AddTestStatus(TestStatus status)
        {
            _sb.AppendLine("Execution status: " + status.ToString());

            return this;
        }

        public SummaryBuilder AddException(Exception exception)
        {
            if (exception == null) throw new ArgumentException("Argument can't be null", nameof(exception));

            _sb.AppendLine("Got exception: " + exception.ToString());

            return this;
        }

        public SummaryBuilder AddDescription(string description)
        {
            if (description == null) throw new ArgumentException("Argument can't be null", nameof(description));

            _sb.AppendLine("Description: " + description);

            return this;
        }

        public Summary Create()
        {
            _summary.Text = _sb.ToString();

            return _summary;
        }
    }

    class TestingEngine
    {
        private TestClassContainer _container;

        private TestExecutor _executor = new TestExecutor();


        public TestingEngine(TestClassContainer container)
        {
            _container = container;
        }

        private ExecuteResult[] TestAll(params Test[] tests)
        {
            return _executor.Execute(tests);
        }

        public Summary[] GetSummaries(params ExecuteResult[] results)
        {
            var summaries = new List<Summary>();

            foreach (var result in results)
            {
                var builder = new SummaryBuilder();

                builder.AddName(result.Test.Name).AddTestStatus(result.Status);

                if (result.Status == TestStatus.Failed)
                {
                    builder.AddException(result.Exception);
                }

                summaries.Add(builder.Create());
            }

            return summaries.ToArray();
        }

        public Test[] GetTests()
        {
            var tests = new List<Test>();

            foreach (var testClass in _container.Get())
            {
                foreach (var method in testClass.GetMethods())
                {
                    tests.Add(new TestBuilder().AddMethod(method).AddName(method.Method.Name).Create());
                }
            }

            return tests.ToArray();
        }

        public Summary[] RunEngine()
        {
            var tests = GetTests();

            var results = TestAll(tests);

            var summaries = GetSummaries(results);

            return summaries;
        }
    }

    class AssertArgumentEqualsException : Exception
    {
        public AssertArgumentEqualsException(string message) : base(message)
        {
        }
    }

    class AssertActionException : Exception
    {
        public AssertActionException(string message) : base(message)
        {
        }
    }


    static class Is
    {
        public static bool True => true;

        public static bool False => false;

        public static bool IsType<T>(object obj)
        {
            return obj is T;
        }
    }
    static class Assert
    {     
        public static void To<T>(T original, T expected)
        {
            if (!original.Equals(expected))
            {
                throw new AssertArgumentEqualsException($"Arguments aren't equals. " +
                    $"\n{nameof(original)}: [{original}] " +
                    $"\n{nameof(expected)}: [{expected}]");
            }
        }

        public static void To<T>(T[] original, T[] expected)
        {
            if (!Enumerable.SequenceEqual(original, expected))
            {
                throw new AssertArgumentEqualsException($"Arguments aren't equals. " +
                    $"\n{nameof(original)}: [{string.Join(" ", original)}] " +
                    $"\n{nameof(expected)}: [{string.Join(" ", expected)}]");
            }
        }

        public static void To<T>(Action action, T exception) where T : Exception
        {
            try
            {
                action.Invoke();
            }
            catch (T ex)
            {
                return;
            }
            catch (Exception ex)
            {
                throw new AssertArgumentEqualsException($"Arguments aren't equals. \nGot: {ex}. \nException: {exception}");
            }

            throw new AssertActionException($"Action don't produce any exception. \nAction: {action.Method.Name}. \nException: {exception}");
        }
    }

    class MyTestClass : BaseTestClass
    {
        public MyTestClass()
        {
            AddMethod(IsTrueTest_True);
            AddMethod(IsFalseTest_True);
        }

        public void IsTrueTest_True()
        {
            bool b = true;

            Assert.To(b, Is.True);
        }

        public void IsFalseTest_True()
        {
            bool b = false;

            Assert.To(b, Is.True);
        }
    }

    partial class Program : MyGridProgram, ITemplate
    {
        TestingEngine Engine;

        public void Init()
        {
            TestClassContainer container = new TestClassContainer();
            container.Add(new MyTestClass());

            Engine = new TestingEngine(container);
        }

        public void Execute(string argument, UpdateType updateSource)
        {
            if(argument == "Testing")
            {
                var summaries = Engine.RunEngine();

                foreach (var summary in summaries)
                {
                    Logger.AddLine(summary.Text);
                }
            }
        }
    }
}
