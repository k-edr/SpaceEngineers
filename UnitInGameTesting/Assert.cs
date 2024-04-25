using System;
using System.Collections.Generic;
using System.Linq;

namespace IngameScript
{
    static class Assert
    {
        public static Is Is { get; }
        public static void To<T>(T real, T expected)
        {
            if (!real.Equals(expected))
            {
                throw new ArgumentException("Arguments are not equal", real.ToString() + expected.ToString());
            }
        }

        public static void To<T>(Action action, T expected ) where T: Exception
        {
            try
            {
                action.Invoke();
            }
            catch (Exception actionException)
            {
                if (!(actionException is T))
                {
                    throw new ArgumentException($"Received exception isn't same as expected. Action exception: {actionException}. Expected exception: {expected}");
                }

                return;
            }

            throw new ArgumentException($"The action do not produce exception.Expected exception: {expected}");
        }
        public static void To<T>(IEnumerable<T> real, IEnumerable<T> expected)
        {
            var rEnumerator = real.GetEnumerator();
            var eEnumerator = expected.GetEnumerator();

            if (!real.Count().Equals(expected.Count()))
            {
                throw new ArgumentException($"Collections size are not equal. Real: {real.Count()}. expected: {expected.Count()}");
            }
            
            do
            {
                if (!rEnumerator.Current.Equals(eEnumerator.Current))
                {
                    throw new ArgumentException($"Collections are not equal. Real: [{string.Join(" ", real)}]. Expected: [{string.Join(" ", expected)}]");
                }

            } while (rEnumerator.MoveNext() && eEnumerator.MoveNext());
        }
    }
}
