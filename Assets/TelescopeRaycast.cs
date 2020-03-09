using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeRaycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // this forward looks the correct distance into the sky
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1000;
        Ray intoSkyRay = new Ray(transform.position, forward);
        
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(intoSkyRay, out hit, 1000f))
        {
            Debug.DrawRay(transform.position, forward, Color.green);
        }
    }
}
