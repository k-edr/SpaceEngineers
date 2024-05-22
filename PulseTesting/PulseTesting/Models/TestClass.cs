using IngameScript.PulseTesting.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngameScript.PulseTesting.Models
{
    public abstract class TestClass : ITestClass
    {
        protected List<TestMethod> _methods = new List<TestMethod>();

        public IEnumerable<TestMethod> Methods => _methods;


        #region add args
        public virtual void Add(Action action) => _methods.Add(new TestMethod(action.Method.Name, this.GetType().Name, action));

        public virtual void Add(string methodName, string className, Action action) => _methods.Add(new TestMethod(methodName, className, action));

        public virtual void Add<T>(Action<T> action, T arg) => Add(action.Method.Name, this.GetType().Name, () => action(arg));

        public virtual void Add<T1, T2>(Action<T1, T2> action, T1 arg1, T2 arg2) => Add(action.Method.Name, this.GetType().Name, ()=>action(arg1, arg2));

        public virtual void Add<T1, T2, T3>(Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3) => Add(action.Method.Name, this.GetType().Name, ()=>action(arg1, arg2, arg3));

        public virtual void Add<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => Add(action.Method.Name, this.GetType().Name, ()=>action(arg1, arg2, arg3, arg4));
        #endregion

        #region add arrs
        public virtual void Add<T>(Action<T[]> action, T[] arg) => Add(action.Method.Name, this.GetType().Name, ()=>action(arg));

        public virtual void Add<T1, T2>(Action<T1[], T2[]> action, T1[] arg1, T2[] arg2) => Add(action.Method.Name, this.GetType().Name, ()=>action(arg1, arg2));

        public virtual void Add<T1, T2, T3>(Action<T1[], T2[], T3[]> action, T1[] arg1, T2[] arg2, T3[] arg3) => Add(action.Method.Name, this.GetType().Name, ()=>action(arg1, arg2, arg3));

        public virtual void Add<T1, T2, T3, T4>(Action<T1[], T2[], T3[], T4[]> action, T1[] arg1, T2[] arg2, T3[] arg3, T4[] arg4) => Add(action.Method.Name, this.GetType().Name, ()=>action(arg1, arg2, arg3, arg4));
        #endregion
    }
}
