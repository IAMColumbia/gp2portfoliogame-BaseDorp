using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float throttle;
    public float reverse;
    public float steer;
    public bool undo = false;

    [SerializeField]
    InputManager Player1;
    [SerializeField]
    InputManager Player2;

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
    }

    // Player 2 Movement
    void PlayerTwoMovement()
    {
        this.throttle = Input.GetAxis("P2_Vertical");
        this.steer = Input.GetAxis("P2_Horizontal");
    }

    // Input for rewind
    void CheckUndo()
    {
        if (Input.GetButton("P1_RewindSelf") || Input.GetButton("P2_RewindOther"))
        {
            Player1.undo = true;
        }
        else
        {
            Player1.undo = false;
        }

        if (Input.GetButton("P2_RewindSelf") || Input.GetButton("P1_RewindOther"))
        {
            Player2.undo = true;
        }
        else
        {
            Player2.undo = false;
        }
    }
}
