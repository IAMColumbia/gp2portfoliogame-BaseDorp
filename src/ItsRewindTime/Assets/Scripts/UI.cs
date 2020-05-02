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
    Text P1Meter;
    [SerializeField]
    Text P2Meter;
    [SerializeField]
    Text P1Lap;
    [SerializeField]
    Text P2Lap;

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
        this.P1Meter.text = "Rewind: " + Player1.rewindMeter.ToString();
        
        this.P2Meter.text = "Rewind: " + Player2.rewindMeter.ToString();
    }

    void UpdateLap()
    {
        this.P1Lap.text = "Lap " + Player1.laps.ToString() + "/" + gm.totalLaps.ToString();
    }
}
