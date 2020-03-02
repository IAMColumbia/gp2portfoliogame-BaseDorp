using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float throttle;
    public float reverse;
    public float steer;
    public bool breaking;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    void UpdateMovement()
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
    }
}
