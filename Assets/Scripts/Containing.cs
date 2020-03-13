using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Containing
{
    int glowIntensity
    {
        get;
    }
    bool stardustCollected
    {
        get;
    }

    public int stardustToCollect
    {
        get;
    }
}
