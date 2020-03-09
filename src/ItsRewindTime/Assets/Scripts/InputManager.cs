using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float throttle;
    public float reverse;
    public float steer;
    public bool breaking;
    public bool undo = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();

        if (Input.GetKey(KeyCode.Backspace))
        {
            this.undo = true;
        }
        else
        {
            this.undo = false;
        }
    }

    public Vector3 UpdateMovement()
    {
        throttle = Input.GetAxis("Forward");
        reverse = Input.GetAxis("Reverse");
        steer = Input.GetAxis("Horizontal");

        throttle = throttle - reverse;

        if (reverse > 0)
        {
            breaking = true;
        }
        else
        {
            breaking = false;
        }

        if (new Vector3(throttle, 0, steer) != Vector3.zero)
        {
            return new Vector3(throttle, 0, steer);
        }
        return Vector3.zero;
    }

    // Input for rewind
    void Undo()
    {
        
    }
}
