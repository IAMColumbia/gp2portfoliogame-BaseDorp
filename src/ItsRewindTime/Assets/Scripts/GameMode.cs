using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    private static GameMode instance;

    public int totalLaps = 3;

    private int numPlayers = 2;
    private List<CarController> players;

    private void Start()
    { 
        // Gets all all objects with the CarController script (which should be only the players)
        Object[] cc = FindObjectsOfType(typeof(CarController));
        foreach (CarController n in cc)
        {
            players.Add(n);
        }
    }

    public void AddPlayer()
    {
        // Future goals to be able to add up to 8 players
        numPlayers++;
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
