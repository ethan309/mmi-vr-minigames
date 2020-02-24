using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class Warp : MonoBehaviour
{
    string[] minigames = {"Observatory", "Stardust", "Copycat"};
    string BASE;
    string focus;

    void Start()
    {
        BASE = SceneManager.GetActiveScene().name;
        focus = BASE;
    }
    
    // Warp to minigame (new scene). 'W' key used for manual debugging.
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.W))
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
