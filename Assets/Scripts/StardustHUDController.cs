using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class StardustHUDController : MonoBehaviour
{
    private bool blocked = false;
    private GameObject container;
    private int totalDust;
    private System.Timers.Timer startTimer;

    public TextMeshProUGUI HUDLeftText;
    public TextMeshProUGUI HUDCenterText;
    public TextMeshProUGUI HUDRightText;
    public TextMeshProUGUI HUDBottomText;

    // Start is called before the first frame update
    void Start()
    {
        blocked = true;
        container = GameObject.FindGameObjectsWithTag("Test Tube")[0];
        totalDust = (container.GetComponent<Containing>()).stardustToCollect;
        PopulateHUDText("", "Collect all the stardust.", "", "You can use this stardust to power your light.");
        StartTimer(5000, ClearHUDText);
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
        HUDLeftText.text = "";
        HUDCenterText.text = "";
        HUDRightText.text = "";
        HUDBottomText.text = "";
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

    void Update()
    {
        if(!blocked)
        {
            int collected = (container.GetComponent<Containing>()).getStardustCollected();
            if(totalDust <= 0)
                totalDust = (container.GetComponent<Containing>()).stardustToCollect;
            String status = "Levels:\n" + collected + "/" + totalDust;
            PopulateHUDText(status, "", "", "");
        }
    }
}
