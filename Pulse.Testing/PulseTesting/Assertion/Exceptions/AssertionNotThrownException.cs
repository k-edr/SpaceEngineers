using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript.Pulse.Testing.Assertion.Exceptions
{
    public class AssertionNotThrownException : Exception
    {
        public AssertionNotThrownException(string message) : base(message)
        {
        }
    }
}
