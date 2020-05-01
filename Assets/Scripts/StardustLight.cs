using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StardustLight : MonoBehaviour
{
    private GameObject container;
    // Start is called before the first frame update
    void Start()
    {
        container = GameObject.FindGameObjectsWithTag("Stardust Container")[0];
        GetComponent<Light>().range = 5;
    }

    // Update is called once per frame
    void Update()
    {
        float newIntensity = (container.GetComponent<Containing>()).getGlowIntensity();
        GetComponent<Light>().intensity = newIntensity;
        if (newIntensity > 0.1) GetComponent<Light>().range = 5 + (newIntensity * 7);
    }
}
