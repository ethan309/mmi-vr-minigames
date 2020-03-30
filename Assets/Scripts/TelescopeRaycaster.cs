using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeRaycaster : MonoBehaviour
{
    public LineRenderer ray;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // this forward looks the correct distance into the sky
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Ray intoSkyRay = new Ray(transform.position, forward);
        
        // Use this to see the ray drawn into the Scene view when the game is running
        // Debug.DrawRay(intoSkyRay.origin, intoSkyRay.direction * 1000, Color.green);

        if (Physics.Raycast(intoSkyRay, out hit, 1000))
        {
            if (hit.collider.tag == "Stardust Warp")
            {
                // run warp code
                // ...
            }
        }
    }
}
