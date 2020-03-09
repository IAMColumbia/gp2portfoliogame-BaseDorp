using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindCommand : Command
{
    private Vector3 direction;

    public RewindCommand(IEntity entity, Vector3 _direction) : base(entity)
    {
        this.direction = _direction;
    }

    public override void Execute()
    {
        // TODO replace with movement speed
        this.entity.transform.position += direction * 0.1f;
    }

    public override void Undo()
    {
        // TODO replace with movement speed
        this.entity.transform.position -= direction * 0.1f;
    }
}
