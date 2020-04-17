using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VerticalPacer : MonoBehaviour
{
    public float range;
    private float minHeight;
    private float maxHeight;
    private const float POSITON_CHANGE_DELAY = 0.01f;
    private float DELTA;
    // Start is called before the first frame update
    void Start()
    {
        DELTA = Random.Range(0.03f, 0.08f);
        minHeight = transform.position.y;
        maxHeight = transform.position.y + range;
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