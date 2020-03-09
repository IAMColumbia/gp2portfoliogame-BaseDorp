using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private List<Command> commands = new List<Command>();
    private int currentCommandIndex;

    public void ExecuteCommand(Command _command)
    {
        commands.Add(_command);
        _command.Execute();
        currentCommandIndex = commands.Count - 1;
    }

    public void Undo()
    {
        if (currentCommandIndex < 0)
        {
            return;
        }

        commands[currentCommandIndex].Undo();
        commands.RemoveAt(currentCommandIndex);
        currentCommandIndex--;
    }
}
