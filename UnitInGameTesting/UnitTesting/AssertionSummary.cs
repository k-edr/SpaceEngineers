using System;
using System.Text;

namespace IngameScript.UnitTesting
{
    public class AssertionSummary
    {
        private StringBuilder _stringBuilder = new StringBuilder();

        public void Add(string str)
        {
            if (str == null) throw new ArgumentNullException("Argument can't be null", nameof(str));

            _stringBuilder.Append(str);
        }

        public void AddLine(string str) => Add("\n" + str);

        public string Get() => _stringBuilder.ToString();
    }
}
