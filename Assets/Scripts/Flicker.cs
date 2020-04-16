﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    private const float MAX_INTENSITY = 5.0f;
    private const float MIN_INTENSITY = 1.25f;
    private const float DELTA = 0.05f;
    private const float LIGHTING_CHANGE_DELAY = 0.01f;

    private Light lightSource;

    void Start()
    {
        lightSource = GetComponent<Light>();
        StartCoroutine(UpdateStardustGlowIntensity(lightSource));
    }

    IEnumerator UpdateStardustGlowIntensity(Light source)
    {
        float delta = DELTA;
        while(true)
        {
            if(source.range > MAX_INTENSITY)
                delta = -DELTA;
            else if(source.range < MIN_INTENSITY)
                delta = DELTA;

            source.range += delta;
            
            yield return new WaitForSeconds(LIGHTING_CHANGE_DELAY);
        }
    }
}