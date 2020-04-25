using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMode gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMode").GetComponent<GameMode>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }
    }
}
