using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class ObservatoryHUDController : MonoBehaviour, HUD
{
    private System.Timers.Timer startTimer;
    private bool blocked;

    public TextMeshProUGUI HUDLeftText;
    public TextMeshProUGUI HUDCenterText;
    public TextMeshProUGUI HUDRightText;
    public TextMeshProUGUI HUDBottomText;

    // Start is called before the first frame update
    void Start()
    {
        blocked = false;
        PushHUDText("", "Start by constructing your telescope.", "", "You will use your telescope to find other worlds.", 10000);
    }

    public bool PushHUDText(String left, String center, String right, String bottom, int duration)
    {
        if(blocked)
        {
            return false;
        }
        PopulateHUDText(left, center, right, bottom);
        blocked = true;
        StartTimer(duration, ClearHUDText);
        return true;
    }

    private void PopulateHUDText(String left, String center, String right, String bottom)
    {
        HUDLeftText.text = left;
        HUDCenterText.text = center;
        HUDRightText.text = right;
        HUDBottomText.text = bottom;
    }

    private void ClearHUDText(System.Object source, ElapsedEventArgs e)
    {
        PopulateHUDText("", "", "", "");
        blocked = false;
    }


    private void StartTimer(int time, ElapsedEventHandler callback)
    {
        // Create a timer with a two second interval.
        startTimer = new System.Timers.Timer(time);
        // Hook up the Elapsed event for the timer. 
        startTimer.Elapsed += callback; //OnTimedEvent;
        startTimer.AutoReset = false;
        startTimer.Enabled = true;
    }

    // void Update()
    // {
    //     if(!blocked)
    //     {
    //         // Update HUD
    //     }
    // }
}