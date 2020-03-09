using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class CarController : MonoBehaviour, IEntity
{
    public InputManager inputManager;
    public CommandManager commandManager;
    public List<WheelCollider> throttleWheels;
    public List<WheelCollider> steeringWheels;
    float strengthCoefficient = 20000f;
    float maxTurn = 20f;

    void Start()
    {
        this.inputManager = GetComponent<InputManager>();
        this.commandManager = GetComponent<CommandManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Translate(new Vector3(inputManager.steer, 0, inputManager.throttle));

        //// Physics for the wheels
        //foreach (WheelCollider wheel in throttleWheels)
        //{
        //    wheel.motorTorque = strengthCoefficient * Time.deltaTime * inputManager.throttle;
        //}

        //// Steering
        //foreach (WheelCollider wheel in steeringWheels)
        //{
        //    wheel.steerAngle = maxTurn * inputManager.steer;
        //}
    }

    void Update()
    {
        // Gets direction from input
        Vector3 direction = this.inputManager.UpdateMovement();

        if (direction != Vector3.zero)
        {
            RewindCommand moveCommand = new RewindCommand(this, direction);
            this.commandManager.ExecuteCommand(moveCommand);
        }

        if (inputManager.undo)
        {
            this.commandManager.Undo();
        }
    }

    public void MoveFromTo(Vector3 startPos, Vector3 endPos)
    {
        
    }
}
