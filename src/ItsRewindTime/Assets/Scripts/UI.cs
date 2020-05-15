using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    GameMode gm;
    [SerializeField]
    CarController Player1;
    [SerializeField]
    CarController Player2;
    [SerializeField]
    Text P1Lap;
    [SerializeField]
    Text P2Lap;
    [SerializeField]
    Slider P1Slider;
    [SerializeField]
    Slider P2Slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMeter();
        UpdateLap();
    }

    void UpdateMeter()
    {
        P1Slider.value = Player1.rewindMeter;
        P2Slider.value = Player2.rewindMeter;
    }

    void UpdateLap()
    {
        if (gm.P1Win)
        {
            this.P1Lap.text = "Player 1 Wins!";
        }
        else if (gm.P2Win)
        {
            this.P2Lap.text = "Player 2 Wins!";
        }
        else
        {
            this.P1Lap.text = "Lap " + Player1.laps.ToString() + "/" + gm.totalLaps.ToString();
            this.P2Lap.text = "Lap " + Player2.laps.ToString() + "/" + gm.totalLaps.ToString();
        }
    }
}
