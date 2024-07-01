using System.Collections.Generic;

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
        while (commands.Count > 0)
        {
            Undo();
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
        while (redoCommands.Count > 0)
        {
            Redo();
        }
    }
}
