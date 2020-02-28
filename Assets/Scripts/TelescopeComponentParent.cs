using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeComponentParent : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // The collision object is what the Component collides with
        if (collision.gameObject.CompareTag("Telescope Pickup Component"))
        {
            // When the component is 'placed', it should be destroyed and should change the color of the telescope itself to opaque
            Destroy(gameObject);
            foreach (Transform child in transform) {
                child.PlaceOpaque();
            }
        }
    }

    void Update()
    {
        // The collision object is what the Component collides with
        if (input.GetKeyUp(KeyCode.R))
        {
            // When the component is 'placed', it should be destroyed and should change the color of the telescope itself to opaque
            foreach (Transform child in transform) {
                child.PlaceOpaque();
            }
        }
    }
}
