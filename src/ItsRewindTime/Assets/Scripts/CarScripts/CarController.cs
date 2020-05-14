using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(CommandManager))]
public class CarController : MonoBehaviour, IEntity
{
    // Movement Variables
    public InputManager inputManager;
    public CommandManager commandManager;
    public List<WheelCollider> throttleWheels;
    public List<GameObject> steeringWheels;
    public List<GameObject> meshWheels;
    float strengthCoefficient = 20000f;
    public float breakStrength;
    float maxTurn = 20f;

    // Rewind Variables
    int frame = 0;
    public float rewindMeter = 0;
    RewindPickup rp;

    // Game Variables
    public int checkpoints = 0;
    public int laps = 0;

    void Awake()
    {
        inputManager = GetComponent<InputManager>();
        commandManager = GetComponent<CommandManager>();
        rp = GetComponent<RewindPickup>();
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
        foreach (GameObject wheel in steeringWheels)
        {
            wheel.GetComponent<WheelCollider>().steerAngle = maxTurn * inputManager.steer;
            //wheel.transform.localEulerAngles = new Vector3(0f, inputManager.steer * maxTurn , 0f);
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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "pickup")
        {
            //rewindMeter += rp.rewindAmount;
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "checkpoint")
        {
            this.checkpoints++;
        }
        else if (collision.gameObject.tag == "finishline")
        {
            // Resets if all checkpoints is hit. Counts as one lap
            if (checkpoints >= 8)
            {   
                this.checkpoints = 0;
                this.laps++;
            }
        }
    }
}
