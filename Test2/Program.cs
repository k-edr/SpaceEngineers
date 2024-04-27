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

    public class ActionModel
    {
        public Action Action { get; set; }

        public string MethodName { get; set; }
    }

    public abstract class BaseTestClass
    {
        private List<ActionModel> actions = new List<ActionModel>();

        internal ActionModel[] GetModels() => actions.ToArray();

        private void AddMethod(Action action, string methodName) => actions.Add(new ActionModel() { Action = action, MethodName = methodName });

        protected internal void AddMethod(Action action) => AddMethod(() => action(), action.Method.Name);

        #region AddMethod<T1...T15>
        protected internal void AddMethod<T1>(Action<T1> action, T1 arg1) => AddMethod(() => action(arg1), action.Method.Name);
        protected internal void AddMethod<T1, T2>(Action<T1, T2> action, T1 arg1, T2 arg2) => AddMethod(() => action(arg1, arg2), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3>(Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3) => AddMethod(() => action(arg1, arg2, arg3), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => AddMethod(() => action(arg1, arg2, arg3, arg4), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15), action.Method.Name);
        #endregion

        #region AddMethod<T1...T15> Arrays
        protected internal void AddMethod<T1, T2>(Action<T1[], T2[]> action, T1[] arg1, T2[] arg2) => AddMethod(() => action(arg1, arg2), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3>(Action<T1[], T2[], T3[]> action, T1[] arg1, T2[] arg2, T3[] arg3) => AddMethod(() => action(arg1, arg2, arg3), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4>(Action<T1[], T2[], T3[], T4[]> action, T1[] arg1, T2[] arg2, T3[] arg3, T4[] arg4) => AddMethod(() => action(arg1, arg2, arg3, arg4), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5>(Action<T1[], T2[], T3[], T4[], T5[]> action, T1[] arg1, T2[] arg2, T3[] arg3, T4[] arg4, T5[] arg5) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6>(Action<T1[], T2[], T3[], T4[], T5[], T6[]> action, T1[] arg1, T2[] arg2, T3[] arg3, T4[] arg4, T5[] arg5, T6[] arg6) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7>(Action<T1[], T2[], T3[], T4[], T5[], T6[], T7[]> action, T1[] arg1, T2[] arg2, T3[] arg3, T4[] arg4, T5[] arg5, T6[] arg6, T7[] arg7) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1[], T2[], T3[], T4[], T5[], T6[], T7[], T8[]> action, T1[] arg1, T2[] arg2, T3[] arg3, T4[] arg4, T5[] arg5, T6[] arg6, T7[] arg7, T8[] arg8) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1[], T2[], T3[], T4[], T5[], T6[], T7[], T8[], T9[]> action, T1[] arg1, T2[] arg2, T3[] arg3, T4[] arg4, T5[] arg5, T6[] arg6, T7[] arg7, T8[] arg8, T9[] arg9) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1[], T2[], T3[], T4[], T5[], T6[], T7[], T8[], T9[], T10[]> action, T1[] arg1, T2[] arg2, T3[] arg3, T4[] arg4, T5[] arg5, T6[] arg6, T7[] arg7, T8[] arg8, T9[] arg9, T10[] arg10) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1[], T2[], T3[], T4[], T5[], T6[], T7[], T8[], T9[], T10[], T11[]> action, T1[] arg1, T2[] arg2, T3[] arg3, T4[] arg4, T5[] arg5, T6[] arg6, T7[] arg7, T8[] arg8, T9[] arg9, T10[] arg10, T11[] arg11) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1[], T2[], T3[], T4[], T5[], T6[], T7[], T8[], T9[], T10[], T11[], T12[]> action, T1[] arg1, T2[] arg2, T3[] arg3, T4[] arg4, T5[] arg5, T6[] arg6, T7[] arg7, T8[] arg8, T9[] arg9, T10[] arg10, T11[] arg11, T12[] arg12) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1[], T2[], T3[], T4[], T5[], T6[], T7[], T8[], T9[], T10[], T11[], T12[], T13[]> action, T1[] arg1, T2[] arg2, T3[] arg3, T4[] arg4, T5[] arg5, T6[] arg6, T7[] arg7, T8[] arg8, T9[] arg9, T10[] arg10, T11[] arg11, T12[] arg12, T13[] arg13) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1[], T2[], T3[], T4[], T5[], T6[], T7[], T8[], T9[], T10[], T11[], T12[], T13[], T14[]> action, T1[] arg1, T2[] arg2, T3[] arg3, T4[] arg4, T5[] arg5, T6[] arg6, T7[] arg7, T8[] arg8, T9[] arg9, T10[] arg10, T11[] arg11, T12[] arg12, T13[] arg13, T14[] arg14) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14), action.Method.Name);
        protected internal void AddMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1[], T2[], T3[], T4[], T5[], T6[], T7[], T8[], T9[], T10[], T11[], T12[], T13[], T14[], T15[]> action, T1[] arg1, T2[] arg2, T3[] arg3, T4[] arg4, T5[] arg5, T6[] arg6, T7[] arg7, T8[] arg8, T9[] arg9, T10[] arg10, T11[] arg11, T12[] arg12, T13[] arg13, T14[] arg14, T15[] arg15) => AddMethod(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15), action.Method.Name);

        #endregion

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

        private TestExecutor _executor;


        public TestingEngine(TestClassContainer container, TestExecutor  executor)
        {
            _container = container;
            _executor = executor;
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
                foreach (var model in testClass.GetModels())
                {
                    tests.Add(new TestBuilder().AddMethod(model.Action).AddName(model.MethodName).Create());
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
            AddMethod(MyTestClass_IsTrueTest_True);
            AddMethod(MyTestClass_IsFalseTest_FailTest);
            AddMethod(MyTestClass_ThrowNullExceptionTest_NullException);
            AddMethod(MyTestClass_Add2Nums, 1, 1, 2);
            AddMethod(MyTestClass_Add2Nums, 1, 2, 3);
            AddMethod(MyTestClass_EqualsArrays_True, new[] { 1, 2 }, new[] { 1, 2 });
            AddMethod(MyTestClass_EqualsArrays_ShouldFail, new[] { 1, 2 }, new[] { 1, 3 });
        }

        public void MyTestClass_EqualsArrays_True(int[] original, int[] expected)
        {
            Assert.To(original, expected);
        }

        //Should be failed
        public void MyTestClass_EqualsArrays_ShouldFail(int[] original, int[] expected)
        {
            Assert.To(original, expected);
        }

        public void MyTestClass_Add2Nums(int left, int right, int result)
        {
            //Arrange

            int sum = 0;

            //Act

            sum = left+ right;

            //Assert

            Assert.To(sum, result);
        }

        public void MyTestClass_IsTrueTest_True()
        {
            bool b = true;

            Assert.To(b, Is.True);
        }

        //Should be failed
        public void MyTestClass_IsFalseTest_FailTest()
        {
            bool b = false;

            Assert.To(b, Is.True);
        }

        public void MyTestClass_ThrowNullExceptionTest_NullException()
        {
            Action act = () => { throw new ArgumentNullException(); };

            Assert.To(act, new ArgumentNullException());
        }


    }

    partial class Program : MyGridProgram, ITemplate
    {
        TestingEngine Engine;

        public void Init()
        {
            TestClassContainer container = new TestClassContainer();
            container.Add(new MyTestClass());

            Engine = new TestingEngine(container, new TestExecutor());
        }

        public void Execute(string argument, UpdateType updateSource)
        {
            if (argument == "Testing")
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
