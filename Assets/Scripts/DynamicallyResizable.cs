using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicallyResizable : MonoBehaviour
{
    public int manualScalingFactor = 1;
    private int previousManualScalingFactor;

    // Start is called before the first frame update
    void Start()
    {
        previousManualScalingFactor = manualScalingFactor;
    }

    // Update is called once per frame
    void Update()
    {
        if(manualScalingFactor != previousManualScalingFactor)
        {
            previousManualScalingFactor = manualScalingFactor;
            ScaleSize(manualScalingFactor);
        }
    }

    void UpdateSize(int xScaling, int yScaling, int zScaling) {
        Vector3 old = gameObject.transform.localScale;
        gameObject.transform.localScale = new Vector3(old.x * xScaling, old.y * yScaling, old.z * zScaling);
    }

    void ScaleSize(int scalingFactor) {
        UpdateSize(scalingFactor, scalingFactor, scalingFactor);
    }
}
