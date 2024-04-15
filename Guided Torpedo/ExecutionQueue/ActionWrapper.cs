using System;

namespace IngameScript.ExecutionQueue
{
    class ActionWrapper
    {
        public static Action CallAction<T1>(Action<T1> action, T1 arg1) => () => action(arg1);

        public static Action CallAction<T1, T2>(Action<T1, T2> action, T1 arg1, T2 arg2) => () => action(arg1, arg2);

        public static Action CallAction<T1, T2, T3>(Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3) => () => action(arg1, arg2, arg3);

        public static Action CallAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => () => action(arg1, arg2, arg3, arg4);

        public static Action CallAction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => () => action(arg1, arg2, arg3, arg4, arg5);
    }
}
