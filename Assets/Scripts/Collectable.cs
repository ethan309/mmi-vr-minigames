using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int collected;

    void OnTriggerEnter(Collider collision)
    {
        // Test Tube is a placeholder name, replace it with whatever the tube/vacuum/light in hand ends up being
        if (collision.gameObject.CompareTag("Test Tube"))
        {
            Destroy(gameObject);
            collected += 1;
            
        }
    }
}
