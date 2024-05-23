using IngameScript.Pulse.Testing.Assertion.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript.Pulse.Testing.Assertion
{
    public static class Assert
    {
        public static void That<T>(T left, T right)
        {
            That(new[] { left }, new[] { right });
        }

        public static void That<T>(T[] left, T[] right)
        {
            if (!left.SequenceEqual(right))
            {
                throw new AssertionArgumentException<T>("Left is't equal to right. ", left, right);
            }
        }
        
        public static void That<E>(Action action, E exception) where E: Exception 
        {
            try
            {
                action.Invoke();
            }catch (E)
            {
                return;
            }
            catch (Exception ex)
            {
                throw new AssertionArgumentException($"Exceptions aren't equals. Expected: {nameof(E)}. But was: {ex}");
            }
            finally
            {
                throw new AssertionNotThrownException($"Expected exception: {nameof(E)}, but the code throw nothing");
            }
        }
    }

}

