using IngameScript.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngameScript.Stuff.Logger
{
    public abstract class BaseLogger : ILogger
    {
        protected bool _needLogger;

        protected BaseLogger(bool needLogger = true)
        {
            _needLogger = needLogger;
        }

        public abstract void Add(string str, object obj = null);

        public virtual void AddLine(string str, object obj = null) => Add(str + "\n", obj);
        
    }
}
