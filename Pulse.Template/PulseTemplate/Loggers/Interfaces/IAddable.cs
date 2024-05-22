namespace IngameScript.Pulse.Template.Loggers.Interfaces
{
    public interface IAddable
    {
        void Add(string message, object data = null);

        void AddLine(string message, object data = null);
    }
}
