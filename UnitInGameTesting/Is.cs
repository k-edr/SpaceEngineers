using System;

namespace IngameScript
{
    class Is
    {
        public const bool True = true;

        public const bool False = false;

        public bool SameType(object obj, Type type)
        {
            return obj != null && obj.GetType() == type;
        }
    }
}
