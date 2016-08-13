using System;
using System.Collections.Generic;
using Pattern_Battle.Observer;

namespace Pattern_Battle.Command
{
    public class Invoker : IObservable
    {
        private readonly List<ICommandsObserver> _observers;
        private readonly Reciever _reciever = new Reciever();
        private readonly List<List<ICommandable>> _commands = new List<List<ICommandable>>();
        private int _commandIndex;

        public Invoker(params ICommandsObserver[] obs)
        {
            _observers = new List<ICommandsObserver>();
            foreach (var commandsObserver in obs)
            {
                _observers.Add(commandsObserver);
            }
        }

        public bool CanUndo()
        {
            return _commandIndex > 0;
        }

        public bool Rewrite;

        public bool CanRedo()
        {
            return _commands.Count > _commandIndex ;
        }

        public void ClearCommands()
        {
            if (_commands.Count != 0)
                _commands.Clear();
            _commandIndex = 0;
        }

        public void CtrlZ(int count = 1)
        {
            Rewrite = true;
            bool somethingChanged = false;
            for (var i = 0; i < count; i++)
                {
                    var commands = new List<ICommandable>(_commands[_commandIndex - 1]);
                    commands.Reverse();
                    foreach (var commandable in commands)
                        commandable.UnExecute(true);
                    _commandIndex--;
                    somethingChanged = true;
                }
            if (somethingChanged)
                NotifyObservers(new FakeCommandArgs { Undo = true });
        }

        public void CtrlY(int count = 1)
        {
            bool somethingChanged = false;
            for (var i = 0; i < count; i++)
                {
                    foreach (var commandable in _commands[_commandIndex])
                        commandable.Execute(true);
                    _commandIndex++;
                    somethingChanged = true;
                }
            if (somethingChanged)
                NotifyObservers(new FakeCommandArgs { Redo = true });
        }

        public void Invoke(CommandType commandType, ICommandArgs commandArgs = null)
        {
            ICommandable command = null; 
            if (commandType != CommandType.None)
            {
                if (Rewrite)
                {
                    _commands.RemoveRange(_commandIndex, _commands.Count - _commandIndex);
                    Rewrite = false;
                }
            }
            switch (commandType)
            {
               
                case CommandType.None:
                    if (_commands[_commandIndex] != null)
                        _commandIndex++;
                    return;
                case CommandType.Damage:
                    var damageCommandArgs = commandArgs as DamageOrHealCommandArgs;
                    if (damageCommandArgs != null)
                        command = new DamageCommand(_reciever, damageCommandArgs.Aim, damageCommandArgs.Points, 
                            damageCommandArgs.Dealer);
                    break;
                case CommandType.Heal:
                    var healCommandArgs = commandArgs as DamageOrHealCommandArgs;
                    if (healCommandArgs != null)
                        command = new DamageCommand(_reciever, healCommandArgs.Aim, -healCommandArgs.Points, 
                            healCommandArgs.Dealer);
                    break;
                case CommandType.Kill:
                    var killCommandArgs = commandArgs as KillOrSpawnCommandArgs;
                    if (killCommandArgs != null)
                        command = new KillCommand(_reciever, killCommandArgs.Army, 
                            killCommandArgs.Creature, killCommandArgs.Position, killCommandArgs.Dealer);
                    break;
                case CommandType.Resurrect:
                    var spawnCommandArgs = commandArgs as KillOrSpawnCommandArgs;
                    if (spawnCommandArgs != null)
                        command = new SpawnCommand(_reciever, spawnCommandArgs.Army, 
                            spawnCommandArgs.Creature, spawnCommandArgs.Position, spawnCommandArgs.Dealer);
                    break;
                case CommandType.EquipKnight:
                    var equipCommandArgs = commandArgs as EquipOrUnEquipKnightCommandArgs;
                    if (equipCommandArgs != null)
                        command = new EqiupKnightCommand(_reciever, equipCommandArgs.Army, 
                            equipCommandArgs.KnightPosition, equipCommandArgs.Dealer);
                    break;
                case CommandType.UnEquipKnight:
                    var unEquipCommandArgs = commandArgs as EquipOrUnEquipKnightCommandArgs;
                    if (unEquipCommandArgs != null)
                        command = new UnEquipKnightCommand(_reciever, unEquipCommandArgs.Army, 
                            unEquipCommandArgs.KnightPosition, unEquipCommandArgs.Dealer);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(commandType), commandType, null);
            }
            if (command == null)
                throw new Exception("Command cannot be created");
            command.Execute();
            NotifyObservers(commandArgs);
            if (_commands.Count < _commandIndex)
            {
                throw new Exception("The number of commands less, than index of the new command");
            }
            if (_commands.Count == _commandIndex)
                _commands.Add(new List<ICommandable>());

            _commands[_commandIndex].Add(command);
        }

        public void AddObserver(ICommandsObserver commandsObserver)
        {
            _observers.Add(commandsObserver);
        }

        public void RemoveObserver(ICommandsObserver commandsObserver)
        {
            _observers.Remove(commandsObserver);
        }

        public void NotifyObservers(ICommandArgs args)
        {
            foreach (var observer in _observers)
            {
                observer.HandleEvent(args);
            }
        }
    }
}