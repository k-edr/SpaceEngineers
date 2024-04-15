namespace IngameScript.Torpedo.Speed
{
    interface IControllableSpeed
    {
        void ControllSpeed();

        void ControllSpeed<T>(T val = null) where T: class;
    }
}
