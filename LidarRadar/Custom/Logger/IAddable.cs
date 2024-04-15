namespace IngameScript.Logger
{

    interface IAddable
    {
        void Add(string str, object obj = null);

        void AddLine(string str, object obj = null);
    }

}
