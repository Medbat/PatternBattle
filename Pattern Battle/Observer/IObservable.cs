using Pattern_Battle.Command;

namespace Pattern_Battle.Observer
{
    public interface IObservable
    {
        void AddObserver(ICommandsObserver commandsObserver);
        void RemoveObserver(ICommandsObserver commandsObserver);
        void NotifyObservers(ICommandArgs args);
    }
}