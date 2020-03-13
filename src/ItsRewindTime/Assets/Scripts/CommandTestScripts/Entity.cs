using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(CommandProcessor))]
public class Entity : MonoBehaviour, IEntity
{
    private InputReader inputReader;
    private CommandProcessor commandProcessor;

    private void Awake()
    {
        inputReader = GetComponent<InputReader>();
        commandProcessor = GetComponent<CommandProcessor>();
    }

    private void Update()
    {
        var direction = inputReader.ReadInput();
        if (direction != Vector3.zero)
        {
            var moveCommand = new MoveCommand(this, direction);
            commandProcessor.ExecuteCommand(moveCommand);
        }

        if (inputReader.ReadUndo())
        {
            commandProcessor.Undo();
        }

        float scaleDirection = inputReader.ReadScale();

        if (scaleDirection != 0f)
        {
            commandProcessor.ExecuteCommand(new ScaleCommand(this, scaleDirection));
        }
    }

    public void MoveFromTo(Vector3 startPos, Vector3 endPos)
    {
        throw new System.NotImplementedException();
    }
}
