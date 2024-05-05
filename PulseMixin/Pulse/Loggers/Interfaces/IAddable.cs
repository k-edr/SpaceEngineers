namespace IngameScript.IngameScript.Pulse.Loggers
{
    public interface IAddable
    {
        void Add(string message, object data = null);

        void AddLine(string message, object data = null);
    }
}
