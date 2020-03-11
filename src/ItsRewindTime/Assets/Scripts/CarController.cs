using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(CommandManager))]
public class CarController : MonoBehaviour, IEntity
{
    public InputManager inputManager;
    public CommandManager commandManager;
    public List<WheelCollider> throttleWheels;
    public List<WheelCollider> steeringWheels;
    float strengthCoefficient = 20000f;
    float maxTurn = 20f;

    void Awake()
    {
        this.inputManager = GetComponent<InputManager>();
        this.commandManager = GetComponent<CommandManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Physics for the wheels
        foreach (WheelCollider wheel in throttleWheels)
        {
            wheel.motorTorque = strengthCoefficient * Time.deltaTime * inputManager.throttle;
        }

        // Steering
        foreach (WheelCollider wheel in steeringWheels)
        {
            wheel.steerAngle = maxTurn * inputManager.steer;
        }
    }

    void Update()
    {
        RewindCommand moveCommand = new RewindCommand(this, this.transform.position, this.transform.rotation, this);
        this.commandManager.ExecuteCommand(moveCommand);

        if (inputManager.undo)
        {
            this.commandManager.Undo();
        }
    }
}
