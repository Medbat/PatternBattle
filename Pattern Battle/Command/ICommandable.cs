namespace Pattern_Battle.Command
{
    public interface ICommandable
    {
        void Execute(bool isUndoRedo = false);
        void UnExecute(bool isUndoRedo = false);
    }
}
