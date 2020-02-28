using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeComponent : MonoBehaviour
{
    public string opaqueMaterialName;
    public string transparentMaterialName;

    // Start is called before the first frame update
    void Start()
    {
        PlaceTransparent();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            PlaceOpaque();
        }
    } 

    public void PlaceOpaque() {
        Material newMat = Resources.Load("Materials/" + opaqueMaterialName, typeof(Material)) as Material;
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material = newMat;
    }

    public void PlaceTransparent() {
        Material newMat = Resources.Load("Materials/" + transparentMaterialName, typeof(Material)) as Material;
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material = newMat;
    }
}
