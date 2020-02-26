using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{
    public float transparency = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        Color materialColor = renderer.material.color;
        renderer.material.color = new Color(materialColor.r, materialColor.g, materialColor.b, transparency);
    }
}
