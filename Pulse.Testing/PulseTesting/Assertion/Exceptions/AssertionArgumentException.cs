using System;

namespace IngameScript.Pulse.Testing.Assertion.Exceptions
{
    class AssertionArgumentException<T> : ArgumentException
    {
        public AssertionArgumentException(string message,T[] left, T[] right )
            :base($"{message} \n\tLeft: [{string.Join(", ", left)}]\n\tRight:[{string.Join(", ", right)}]")
        {            
        }

    }

    class AssertionArgumentException : ArgumentException
    {
        public AssertionArgumentException(string message) : base(message) { }
    }
}
