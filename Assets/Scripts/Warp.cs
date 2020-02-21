using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    string[] minigames = {"Observatory", "Stardust", "Copycat"};
    const string BASE = minigames[0];
    string focus = BASE;

    // Update is called once per frame
    void Update()
    {
        if(focus != BASE)
        {
            print("Loading scene: " + focus);
            SceneManager.LoadScene(focus);
        }
    }
}
