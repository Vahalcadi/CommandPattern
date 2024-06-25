using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor
{
    private Stack<ICommand> commands = new Stack<ICommand>();

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
            command.Undo();
        }
    }
}
