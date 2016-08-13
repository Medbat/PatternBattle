namespace Pattern_Battle.Command
{
    public class FakeCommandArgs : ICommandArgs
    {
        public bool Undo;
        public bool Redo;
        public bool DeadLock;
    }
}