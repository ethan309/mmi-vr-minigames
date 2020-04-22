using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Warp : MonoBehaviour
{
    public SteamVR_Action_Boolean gripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "GrabGrip");
    public string target;
    public bool onlyObservatory;

    string BASE;
    private GameObject raycaster;

    void Start()
    {
        BASE = SceneManager.GetActiveScene().name;
        raycaster = GameObject.Find("Telescope Raycaster");
    }
    
    // Warp to minigame (new scene). 'R' key used for manual debugging.
    void Update()
    {
        if (onlyObservatory) {
            target = BASE;
        } else {
            target = raycaster.GetComponent<TelescopeRaycaster>().warpTag;
        }

        // PRODUCTION TRIGGER (controller grip press) or DEBUG TRIGGER ('R' keypress).
        bool shouldWarp = gripAction.state || Input.GetKeyUp(KeyCode.R);
        if(shouldWarp)
        {
            if(target != null && target != BASE)
            {
                // minigame selected.
                print("Loading scene: " + target);
                Valve.VR.SteamVR_LoadLevel.Begin(target);
            }
            else if(target == BASE)
            {
                // return to observatory.
                print("Exiting telescope view (in scene: " + target + ").");
            }
            else
            {
                // Play error sound, etc.
                print("Invalid telescope selection.");
            }
        }
    }
}
