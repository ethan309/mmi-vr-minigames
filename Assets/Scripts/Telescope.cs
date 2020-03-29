using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telescope : MonoBehaviour
{
    public bool lensPlaced;
    public bool bodyPlaced;
    public bool eyePiecePlaced;
    public GameObject lens;

    void Start()
    {
        lensPlaced = false;
        bodyPlaced = false;
        eyePiecePlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform) 
        {
            Transform childTransform = child.GetChild(0);
            GameObject component = childTransform.gameObject;
            TelescopeComponentParent piece = component.GetComponent<TelescopeComponentParent>();
            if (piece != null)
            {
                if (component.ToString() == "Eye Piece (UnityEngine.GameObject)") {
                    eyePiecePlaced = piece.placed;
                } else if (component.ToString() == "Body (UnityEngine.GameObject)") {
                    bodyPlaced = piece.placed;
                } else if (component.ToString() == "Lens (UnityEngine.GameObject)") {
                    lensPlaced = piece.placed;
                }

                if (lensPlaced && bodyPlaced && eyePiecePlaced) {
                    lens.transform.gameObject.SetActive(true);
                }
            }
        }
    }
}
