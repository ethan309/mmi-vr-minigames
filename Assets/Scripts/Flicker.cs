using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public float maxRange;
    public float minRange;

    private Light lightSource;

    void Start()
    {
        minRange = 1.0f;
        maxRange = 5.0f;
        lightSource = GetComponent<Light>();
    }

    void Update()
    {
        if (lightSource.range >= maxRange) StartCoroutine(DecreaseRange(lightSource));
        else if (lightSource.range <= minRange) StartCoroutine(IncreaseRange(lightSource));
    }

    // IEnumerator DoFlicker()
    // {
    //     if (lightSource.range <= minRange)
    //     {
    //         yield return StartCoroutine(IncreaseRange(lightSource));
    //     }

    //     if (lightSource.range >= maxRange) 
    //     {
    //         yield return StartCoroutine(DecreaseRange(lightSource));
    //     }
    //     print(lightSource.range);
    // }

    IEnumerator IncreaseRange(Light source)
    {
        while (source.range <= maxRange)
        {
            source.range += 0.5f;
            yield return source;
        }
    }

    IEnumerator DecreaseRange(Light source)
    {
        while (source.range >= minRange)
        {
            source.range -= 0.5f;
            yield return source;
        }
    }
}