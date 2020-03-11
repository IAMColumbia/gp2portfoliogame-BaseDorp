using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCommand : Command
{
    private readonly float scaleFactor;

    public ScaleCommand(IEntity entity, float scaleDirection) : base(entity)
    {
        this.scaleFactor = scaleDirection == 1f ? 1.1f : 0.9f;
    }

    public override void Execute()
    {
        entity.transform.localScale *= scaleFactor;
    }

    public override void Undo()
    {
        entity.transform.localScale /= scaleFactor;
    }
}
