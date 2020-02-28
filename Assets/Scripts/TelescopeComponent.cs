using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeComponent : MonoBehaviour, Guideable
{
    public Material opaqueMaterial;
    public Material transparentMaterial;

    // Start is called before the first frame update
    void Start()
    {
        PlaceTransparent();
    }

    public void PlaceOpaque() {
        //Material newMat = Resources.Load("Materials/" + opaqueMaterialName, typeof(Material)) as Material;
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material = opaqueMaterial;
    }

    public void PlaceTransparent() {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material = transparentMaterial;
    }
}
