namespace IngameScript.Pulse.Testing.Models
{
    public class TestResult
    {
        public string MethodName { get; set; }

        public string ClassName { get; set; }

        public long ExecuteTime { get; set; }

        public bool Status { get; set; }

        public string Message { get; set; }
    }
}
