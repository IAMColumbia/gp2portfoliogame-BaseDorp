using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindCommand : Command
{
    private Vector3 position;
    private Quaternion rotation;
    private CarController car;

    public RewindCommand(IEntity entity, Vector3 _pos, Quaternion _rot, CarController _car) : base(entity)
    {
        this.position = _pos;
        this.rotation = _rot;
        this.car = _car;
    }

    public override void Execute()
    {
        this.car.transform.position = this.position;
        this.car.transform.rotation = this.rotation;
    }

    public override void Undo()
    {
        this.car.transform.position = this.position;
        this.car.transform.rotation = this.rotation;
    }
}
