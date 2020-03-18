using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Containing
{
    float getGlowIntensity();
    int getStardustCollected();
    
    int stardustToCollect
    {
        get;
    }
}
