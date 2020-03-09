using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    private System.Timers.Timer startTimer;
    public TextMeshProUGUI HUDCenterText;

    // Start is called before the first frame update
    void Start()
    {
        HUDCenterText.text = "Instructions here.";
        StartTimer(5000);
    }

    private void OnTimedEvent(System.Object source, ElapsedEventArgs e)
    {
        HUDCenterText.text = "Go!";
    }


    private void StartTimer(int time)
    {
        // Create a timer with a two second interval.
        startTimer = new System.Timers.Timer(time);
        // Hook up the Elapsed event for the timer. 
        startTimer.Elapsed += OnTimedEvent;
        startTimer.AutoReset = false;
        startTimer.Enabled = true;
    }
}
