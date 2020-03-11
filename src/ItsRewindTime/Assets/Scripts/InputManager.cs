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

    void Update()
    {
        // Checks wether this is player 1 or 2
        switch (this.name)
        {
            case "Player1":
                this.PlayerOneMovement();
                break;
            case "Player2":
                this.PlayerTwoMovement();
                break;
        }

        this.CheckUndo();
    }

    // Player 1 Movement
    void PlayerOneMovement()
    {
        this.throttle = Input.GetAxis("P1_Vertical");
        this.steer = Input.GetAxis("P1_Horizontal");

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

    // Player 2 Movement
    void PlayerTwoMovement()
    {
        this.throttle = Input.GetAxis("P2_Vertical");
        this.steer = Input.GetAxis("P2_Horizontal");

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
    void CheckUndo()
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
