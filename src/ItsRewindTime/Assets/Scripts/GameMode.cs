using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    private static GameMode instance;
    
    [SerializeField]
    public int totalLaps = 3;

    public bool P1Win = false;
    public bool P2Win = false;

    //private int numPlayers = 2;
    //private List<CarController> players;

    [SerializeField]
    CarController Player1;
    [SerializeField]
    CarController Player2;

    private void Start()
    { 
        // Gets all all objects with the CarController script (which should be only the players)
        //Object[] cc = FindObjectsOfType(typeof(CarController));
        //foreach (CarController n in cc)
        //{
        //    players.Add(n);
        //}
    }

    public void AddPlayer()
    {
        // Future goals to be able to add up to 8 players
        //numPlayers++;
    }

    void WinCondition()
    {
        if (Player1.laps >= totalLaps)
        {
            Player1.gameObject.GetComponent<CarController>().enabled = false;
            P1Win = true;
        }
        else if (Player2.laps >= totalLaps)
        {
            Player2.gameObject.GetComponent<CarController>().enabled = false;
            P1Win = true;
        }
    }

    #region Singleton
    // Singleton
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
