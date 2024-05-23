namespace IngameScript.Pulse.Logging.Interfaces
{
    public interface IAddable
    {
        void Add(string message, object data = null);

        void AddLine(string message, object data = null);
    }
}
