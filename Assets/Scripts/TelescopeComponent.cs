using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeComponent : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        // The collision object is what the Component collides with
        if (collision.gameObject.CompareTag("Telescope Component"))
        {
            // When the component is 'placed', it should be destroyed and should change the color of the telescope itself to opaque
            Destroy(gameObject);
            ChangeTransparency(1.0f, collision.gameObject);
        }
    }

    void ChangeTransparency(float newTransparency, GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        Color materialColor = GetComponent<Renderer>().material.color;
        renderer.material.color = new Color(materialColor.r, materialColor.g, materialColor.b, newTransparency);
    }
}
