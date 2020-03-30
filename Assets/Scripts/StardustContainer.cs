using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class StardustContainer : MonoBehaviour, Containing
{
    private int TOTAL_STARDUST;

    public int stardustToCollect
    {
        get
        {
            return TOTAL_STARDUST;
        }
    }

    private int stardust;

    public int getStardustCollected()
    {
        return stardust;
    }

    public float getGlowIntensity()
    {
        if(stardust <= 0)
        {
            return 1.0F;
            //return Math.Min(0.1F, (1/TOTAL_STARDUST));
        }
        return 10.0f * ((float) stardust / (float) TOTAL_STARDUST);
    }

    // Start is called before the first frame update
    void Start()
    {
        stardust = 0;
        TOTAL_STARDUST = GameObject.FindGameObjectsWithTag("Stardust").Length;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Stardust"))
        {
            Destroy(collision.gameObject);
            stardust += 1;
        }
    }
}
