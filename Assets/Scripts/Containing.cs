using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Containing
{
    float glowIntensity
    {
        get;
    }
    bool stardustCollected
    {
        get;
    }

    int stardustToCollect
    {
        get;
    }
}
