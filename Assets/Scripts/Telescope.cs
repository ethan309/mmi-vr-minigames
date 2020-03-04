using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telescope : MonoBehaviour
{
    public bool lensPlaced;
    public bool bodyPlaced;
    public bool scopePlaced;
    public GameObject lens;

    void Start()
    {
        lensPlaced = false;
        bodyPlaced = false;
        scopePlaced = false;
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
                // TODO: make piece names uniform with boolean names
                if (component.ToString() == "piece1 (UnityEngine.GameObject)") {
                    scopePlaced = piece.placed;
                } else if (component.ToString() == "piece2 (UnityEngine.GameObject)") {
                    bodyPlaced = piece.placed;
                } else if (component.ToString() == "piece3 (UnityEngine.GameObject)") {
                    lensPlaced = piece.placed;
                }

                if (lensPlaced && bodyPlaced && scopePlaced) {
                    lens.transform.gameObject.SetActive(true);
                }
                // if (piece.placed) {
                //     placed += 1;

                // }

                // if (piece.placed) {
                //     lens.transform.gameObject.SetActive(true);
                // }
            }
        }
    }
}
