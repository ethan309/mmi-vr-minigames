using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int stardustCollected
    {
        get
        {
            return stardust;
        }
        set
        {
            if(value >= 0)
            {
                stardust = value;
            }
        }
    }

    public float glowIntensity
    {
        get
        {
            if(stardustCollected <= 0)
            {
                return 0.1F;
            }
            return (stardustCollected + 1) / TOTAL_STARDUST;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stardust = 0;
        TOTAL_STARDUST = GameObject.FindGameObjectsWithTag("Stardust").Length;
    }

    // Update is called once per frame
    void OnTriggerEvent(Collider collision)
    {
        if(collision.gameObject.CompareTag("Stardust"))
        {
            Destroy(gameObject);
            stardustCollected += 1;
        }
    }
}
