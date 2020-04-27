using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Warp : MonoBehaviour
{
    public SteamVR_Action_Boolean gripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "GrabGrip");
    public bool canWarp; // telescope is built
    public string target; // telescope is pointed at...
    private string BASE;
    private GameObject raycaster;
    private HUD playerView;
    private GameObject[] telescopeComponents;
    void Start()
    {
        telescopeComponents = new GameObject[] {
            GameObject.Find("piece1"), 
            GameObject.Find("piece2"), 
            GameObject.Find("piece3")
        };
        canWarp = false;
        BASE = SceneManager.GetActiveScene().name;
        raycaster = GameObject.Find("Telescope Raycaster");
        GameObject view = GameObject.Find("HUD View"); // .FindGameObjectWithTag("HUD");
        playerView = view.GetComponent<HUD>();
    }

    bool IsTelescopeComplete() {
        return Array.TrueForAll(telescopeComponents, (component) => component.GetComponent<Placeable>().isPlaced());
    }
    
    // Warp to minigame (new scene).
    void Update()
    {
        target = raycaster.GetComponent<TelescopeRaycaster>().warpTag;

        // PRODUCTION TRIGGER (controller grip press) or DEBUG TRIGGER ('R' keypress).
        bool shouldWarp = gripAction.state || Input.GetKeyUp(KeyCode.R);
        if(shouldWarp)
        {
            bool sceneSelected = target != null && target != BASE;
            bool canWarp = IsTelescopeComplete();
            if(canWarp && sceneSelected) // minigame selected and telescope built
            {
                playerView.PushHUDText("", "Warping", "", "", 2500);
                print("Loading scene: " + target);
                Valve.VR.SteamVR_LoadLevel.Begin(target);
            }
            else if(canWarp) // return to observatory.
            {
                playerView.PushHUDText("", "You must aim your telescope beforre you warp.", "", "Aim at the planet you woould like to which you want to travel.", 5000);
               // print("Invalid telescope selection.");
            }
            else // Play error sound, etc.
            {
                playerView.PushHUDText("", "You cannot warp to other worlds.", "", "You must complete your telescope first.", 5000);
                //print("Telescope not complet.");
            }
        }
    }
}
