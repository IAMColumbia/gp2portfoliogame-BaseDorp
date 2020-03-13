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

    int frame = 0;

    void Awake()
    {
        inputManager = GetComponent<InputManager>();
        commandManager = GetComponent<CommandManager>();
    }
    
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
        // TODO change so command isn't being created every frame
        //frame++;
        // Only creates new command every n amount of seconds
        //if (frame % 1 == 0)
        //{
        // Makes sure new commands are not being created while rewinding
        
            if (inputManager.undo)
            {
                commandManager.Undo();
            }
            else
            {
                RewindCommand moveCommand = new RewindCommand(this, this.transform.position, this.transform.rotation, this);
                commandManager.ExecuteCommand(moveCommand);
            }
        //}
    }
}
