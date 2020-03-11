﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private List<Command> commands = new List<Command>();
    private int currentCommandIndex;

    public void ExecuteCommand(Command _command)
    {
        // Adds the current command to the list of commands
        this.commands.Add(_command);
        // Runs the command
        _command.Execute();
        this.currentCommandIndex = this.commands.Count - 1;
    }

    public void Undo()
    {
        // Does nothing if there is no commands
        if (currentCommandIndex < 0)
        {
            return;
        }

        // Undo's the current command
        this.commands[currentCommandIndex].Undo();
        // Removes it from the list
        this.commands.RemoveAt(currentCommandIndex);
        this.currentCommandIndex--;
    }
}
