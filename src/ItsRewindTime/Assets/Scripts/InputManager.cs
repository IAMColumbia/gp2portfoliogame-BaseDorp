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
    void FixedUpdate()
    {
        switch (this.name)
        {
            case "Player1":
                PlayerOneMovement();
                break;
            case "Player2":
                PlayerTwoMovement();
                break;
        }

        Undo();
    }

    void PlayerOneMovement()
    {
        throttle = Input.GetAxis("P1_Vertical");
        steer = Input.GetAxis("P1_Horizontal");

       // throttle = throttle - reverse;

        if (reverse > 0)
        {
            breaking = true;
        }
        else
        {
            breaking = false;
        }
    }

    void PlayerTwoMovement()
    {
        throttle = Input.GetAxis("P2_Vertical");
        steer = Input.GetAxis("P2_Horizontal");

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

    // Input for rewind
    void Undo()
    {
        switch (this.name)
        {
            case "Player1":
                if (Input.GetButton("P1_Rewind"))
                {
                    this.undo = true;
                }
                else
                {
                    this.undo = false;
                }
                break;
            case "Player2":

                if (Input.GetButton("P2_Rewind"))
                {
                    this.undo = true;
                }
                else
                {
                    this.undo = false;
                }
                break;
        }
    }
}
