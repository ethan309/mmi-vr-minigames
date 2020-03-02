using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeComponentParent : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // The collision object is what the Component collides with
        if (other.gameObject.CompareTag("Telescope Pickup Component"))
        {
            // When the component is 'placed', it should be destroyed and should change the color of the telescope itself to opaque
            Destroy(other.gameObject);
            foreach (Transform child in transform) {
                child.GetComponent<Guideable>().PlaceOpaque();
            }
        }
    }

    void Update()
    {
        // The collision object is what the Component collides with
        if (Input.GetKeyUp(KeyCode.R))
        {
            // When the component is 'placed', it should be destroyed and should change the color of the telescope itself to opaque
            foreach (Transform child in transform) {
                child.GetComponent<Guideable>().PlaceOpaque();
            }
        }
    }
}
