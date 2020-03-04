using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeComponentParent : MonoBehaviour
{
    public bool placed = false;
    public string tag;

    void OnTriggerEnter(Collider other)
    {
        // The collision object is what the Component collides with
        // Need three different pairs of collision detectors to match each real piece to its frame

        if (other.gameObject.CompareTag(tag))
        {
            placed = true;
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
            placed = true;
            // When the component is 'placed', it should be destroyed and should change the color of the telescope itself to opaque
            foreach (Transform child in transform) {
                child.GetComponent<Guideable>().PlaceOpaque();
            }
        }
    }
}
