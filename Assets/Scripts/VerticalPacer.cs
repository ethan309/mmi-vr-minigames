using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VerticalPacer : MonoBehaviour
{
    public float range;
    private float minHeight;
    private float maxHeight;
    private const float POSITON_CHANGE_DELAY = 0.01f;
    private const float DELTA = 0.04f;
    // Start is called before the first frame update
    void Start()
    {
        // print("Current position: " + transform.position.y);
        minHeight = transform.position.y;
        maxHeight = transform.position.y + range;
        // print("Min Height: " + minHeight);
        // print("Max Height: " + maxHeight);
        StartCoroutine(UpdateVerticalPosition());
    }
    IEnumerator UpdateVerticalPosition()
    {
        float delta = DELTA;
        float height = minHeight;
        while (true) 
        {
            if (transform.position.y > maxHeight)
                delta = -DELTA;
            else if (transform.position.y < minHeight)
                delta = DELTA;
            height += delta;
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
            yield return new WaitForSeconds(POSITON_CHANGE_DELAY);
        }
    }
}