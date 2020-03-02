using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telescope : MonoBehaviour
{
    public int placed = 0;
    public GameObject lens;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform) 
        {
            if (child.getChild(0).placed) {
                placed += 1;
            }

            if (placed >= 3) {
                lens.transform.gameObject.SetActive(true);
            }
        }
    }
}
