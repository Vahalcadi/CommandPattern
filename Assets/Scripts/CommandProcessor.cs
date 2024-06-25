using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor
{
    private Stack<ICommand> commands = new Stack<ICommand>();
    private Stack<ICommand> redoCommands = new Stack<ICommand>();

    public void Execute(ICommand command)
    {
        commands.Push(command);
        command.Execute();
    }

    public void Undo()
    {
        ICommand command;
        if (commands.TryPop(out command))
        {
            redoCommands.Push(command);
            command.Undo();
        }
    }

    public void UndoAll()
    {
        ICommand currentCommand;

        while (commands.Count > 0)
        {
            if (commands.TryPop(out currentCommand))
            {
                redoCommands.Push(currentCommand);
                currentCommand.Undo();
            }
        }
    }

    public void Redo()
    {
        ICommand command;
        if (redoCommands.TryPop(out command))
        {
            commands.Push(command);
            command.Execute();
        }
    }

    public void RedoAll()
    {
        ICommand currentCommand;

        while (redoCommands.Count > 0)
        {
            if (redoCommands.TryPop(out currentCommand))
            {
                commands.Push(currentCommand);
                currentCommand.Execute();
            }
        }
    }
}
