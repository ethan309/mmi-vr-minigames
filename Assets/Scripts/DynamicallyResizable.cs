using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class DynamicallyResizable : MonoBehaviour
{
    public float manualScalingFactor = 1;
    private float previousManualScalingFactor;
    private GameObject scalingSlider;

    // Start is called before the first frame update
    void Start()
    {
        scalingSlider = GameObject.FindGameObjectsWithTag("Player Size Adjustment Slider")[0];
        manualScalingFactor = (float) scalingSlider.GetComponent<Slider>().value;
        previousManualScalingFactor = manualScalingFactor;
    }

    // Update is called once per frame
    void Update()
    {
        manualScalingFactor = (float) scalingSlider.GetComponent<Slider>().value;
        if(manualScalingFactor != previousManualScalingFactor)
        {
            previousManualScalingFactor = manualScalingFactor;
            ScaleSize(manualScalingFactor);
        }
    }

    void UpdateSize(float xScaling, float yScaling, float zScaling)
    {
        Vector3 old = gameObject.transform.position;
        gameObject.transform.localScale = new Vector3(xScaling, yScaling, zScaling);
        gameObject.transform.position = old;
    }

    void ScaleSize(float scalingFactor)
    {
        UpdateSize(scalingFactor, scalingFactor, scalingFactor);
    }
}
