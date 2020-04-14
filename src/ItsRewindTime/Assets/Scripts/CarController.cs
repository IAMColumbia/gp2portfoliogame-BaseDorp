using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(CommandManager))]
public class CarController : MonoBehaviour, IEntity
{
    public InputManager inputManager;
    public CommandManager commandManager;
    public List<WheelCollider> throttleWheels;
    public List<WheelCollider> steeringWheels;
    float strengthCoefficient = 20000f;
    public float breakStrength;
    float maxTurn = 20f;

    int frame = 0;
    [SerializeField]
    public float rewindMeter = 100;

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
            if (inputManager.brake)
            {
                wheel.motorTorque = 0f;
                wheel.brakeTorque = breakStrength * Time.deltaTime;
            }
            else
            {
                // Dont want to be setting the torque if the car is breaking
                wheel.motorTorque = strengthCoefficient * Time.deltaTime * inputManager.throttle;
                wheel.brakeTorque = 0f;
            }
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
        // will probably have to smooth the movement between commands
        //frame++;
        // Only creates new command every n amount of seconds
        //if (frame % 1 == 0)
        //{
        // Makes sure new commands are not being created while rewinding
        
            if (inputManager.undo && rewindMeter > 0)
            {
                commandManager.Undo();
                this.rewindMeter--;
            }
            else
            {
                RewindCommand moveCommand = new RewindCommand(this, this.transform.position, this.transform.rotation, this);
                commandManager.ExecuteCommand(moveCommand);
                this.rewindMeter++;
            }
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "pickup")
        {
            //rewindMeter += rewindPickup;
        }
    }
}
