using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StardustContainer : MonoBehaviour, Containing
{
    private int stardust;

    private int TOTAL_STARDUST;

    public int stardustToCollect
    {
        get
        {
            return TOTAL_STARDUST;
        }
    }

    public bool stardustCollected
    {
        get
        {
            return stardust == TOTAL_STARDUST;
        }
    }

    public float glowIntensity
    {
        get
        {
            if(stardust <= 0)
            {
                return 0.1F;
            }
            return (stardust + 1) / TOTAL_STARDUST;
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
        if (collision.gameObject.CompareTag("Stardust"))
        {
            Destroy(gameObject);
            UpdateStardust(stardust + 1);
        }
    }

    private void  UpdateStardust(int newStardustValue)
    {
        stardust = newStardustValue;
    }
}
