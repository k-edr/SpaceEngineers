using IngameScript.Pulse.Testing;
using IngameScript.Pulse.Testing.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngameScript.Pulse.Testing.Interfaces
{
    public interface ITestClass
    {
        IEnumerable<TestMethod> Methods { get; }

        #region add args
        void Add(Action action);

        void Add(string methodName, string className, Action action);

        void Add<T>(Action<T> action, T arg);

        void Add<T1, T2>(Action<T1, T2> action, T1 arg1, T2 arg2);

        void Add<T1, T2, T3>(Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3);

        void Add<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
        #endregion

        #region add arrs
        void Add<T>(Action<T[]> action, T[] arg);

        void Add<T1, T2>(Action<T1[], T2[]> action, T1[] arg1, T2[] arg2);

        void Add<T1, T2, T3>(Action<T1[], T2[], T3[]> action, T1[] arg1, T2[] arg2, T3[] arg3);

        void Add<T1, T2, T3, T4>(Action<T1[], T2[], T3[], T4[]> action, T1[] arg1, T2[] arg2, T3[] arg3, T4[] arg4);
        #endregion
    }
}
