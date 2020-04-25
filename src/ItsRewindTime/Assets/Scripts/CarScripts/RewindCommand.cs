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
        // Stores the current position and rotation of the car at the state of the command is created
        this.car.transform.position = this.position;
        this.car.transform.rotation = this.rotation;
    }

    public override void Undo()
    {
        // Sets the pos and rot of the car to what the pos and rot was in the command
        this.car.transform.position = this.position;
        this.car.transform.rotation = this.rotation;
    }
}
