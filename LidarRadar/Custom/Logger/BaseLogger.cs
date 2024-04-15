using IngameScript.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript.Stuff.Logger
{
    abstract class BaseLogger : ILogger
    {
        protected bool _needUseLogger;

        protected BaseLogger(bool needUseLogger = true)
        {
            _needUseLogger = needUseLogger;
        }

        public abstract void Add(string str, object obj = null);

        public void AddLine(string str, object obj = null) => Add(string.Join("\n", str), obj);
        
    }
}
