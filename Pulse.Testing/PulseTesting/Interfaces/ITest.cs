using System;
using System.Collections.Generic;
using System.Text;

namespace IngameScript.PulseTesting.Interfaces
{
    interface ITest
    {
        string ClassName { get; }

        string MethodName { get; }

        Action Fixture { get; }

    }
}
