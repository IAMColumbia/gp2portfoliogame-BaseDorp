using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    private Vector3 direction;

    public MoveCommand(IEntity entity, Vector3 _direction) : base(entity)
    {
        direction = _direction;
    }

    public override void Execute()
    {
        entity.transform.position += direction * .1f;
    }

    public override void Undo()
    {
        entity.transform.position -= direction * .1f;
    }
}
