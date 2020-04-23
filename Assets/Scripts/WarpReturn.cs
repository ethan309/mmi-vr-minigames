using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class WarpReturn : MonoBehaviour
{
    public SteamVR_Action_Boolean gripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "GrabGrip");
    public bool canWarp;
    private System.Timers.Timer confirmTimer;
    private const string target = "Observatory";
    private HUD playerView;
    void Start()
    {
        canWarp = false;
        playerView = GameObject.Find("HUD View").GetComponent<HUD>();
    }

    private void StartTimer(int time, ElapsedEventHandler callback)
    {
        // Create a timer with a two second interval.
        confirmTimer = new System.Timers.Timer(time);
        // Hook up the Elapsed event for the timer. 
        confirmTimer.Elapsed += callback; //OnTimedEvent;
        confirmTimer.AutoReset = false;
        confirmTimer.Enabled = true;
    }
    
    // Warp to minigame (new scene).
    void Update()
    {
        // PRODUCTION TRIGGER (controller grip press) or DEBUG TRIGGER ('R' keypress).
        bool shouldWarp = gripAction.state || Input.GetKeyUp(KeyCode.R);
        if(shouldWarp)
        {
            if(canWarp) // minigame selected and telescope built
            { 
                print("Loading scene: " + target);
                Valve.VR.SteamVR_LoadLevel.Begin(target);
            }
            else
            {
                const int timeToConfirm = 10000;
                // Push warning to HUD: 
                playerView.PushHUDText("", "Are you sure you want to return home?", "", "Press teleport button(s) again to confirm.", timeToConfirm);
                canWarp = true;
                StartTimer(timeToConfirm, (System.Object source, ElapsedEventArgs e) => canWarp = false);
            }
        }
    }
}
