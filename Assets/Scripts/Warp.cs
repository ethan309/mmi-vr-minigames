using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class Warp : MonoBehaviour
{
    public string target;
    public bool onlyObservatory;

    string BASE;
    string focus;
    private GameObject raycaster;

    void Start()
    {
        BASE = SceneManager.GetActiveScene().name;
        focus = BASE;
        raycaster = GameObject.Find("Telescope Raycaster");
    }
    
    // Warp to minigame (new scene). 'R' key used for manual debugging.
    void Update()
    {
        if (onlyObservatory) {
            target = "Observatory"
        } else {
            target = raycaster.GetComponent<TelescopeRaycaster>().warpTag;
        }

        if(Input.GetKeyUp(KeyCode.R))
        {
            if(focus != null && focus != BASE)
            {
                // minigame selected.
                print("Loading scene: " + focus);
                Valve.VR.SteamVR_LoadLevel.Begin(focus);
            }
            else if(focus == BASE)
            {
                // return to observatory.
                print("Exiting telescope view.");
            }
            else
            {
                // Play error sound, etc.
                print("Invalid telescope selction.");
            }
        }
    }
}
