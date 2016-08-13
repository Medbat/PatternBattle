using Pattern_Battle.Command;

namespace Pattern_Battle.Observer
{
    public interface ICommandsObserver
    {
        void HandleEvent(ICommandArgs args);
    }
}
