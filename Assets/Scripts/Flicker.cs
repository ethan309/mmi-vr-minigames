﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    private float MAX_INTENSITY = 5.0f;
    private float MIN_INTENSITY = 1.25f;
    private float DELTA = 0.05f;

    private Light lightSource;

    void Start()
    {
        lightSource = GetComponent<Light>();
        StartCoroutine(UpdateStardustGlowIntensity(lightSource));
    }

    IEnumerator UpdateStardustGlowIntensity(Light source)
    {
        float delta = 0.05f;
        while(true)
        {
            if(source.range > MAX_INTENSITY)
                delta = -DELTA;
            else if(source.range < MIN_INTENSITY)
                delta = DELTA;

            source.range += delta;
            
            yield return new WaitForSeconds(0.01f);
        }
    }
}