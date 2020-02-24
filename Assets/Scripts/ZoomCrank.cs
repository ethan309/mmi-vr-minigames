using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;

public class ZoomCrank : MonoBehaviour
{

    public Camera targetCamera;
    public GameObject targetCrank;
    private int axisOfRotation;
    private float maxRotation;
    private float rotation;
    private int cycles;
    private float oldRotation;

    // Start is called before the first frame update
    void Start()
    {
        CircularDrive circularDrive = targetCrank.GetComponent <CircularDrive> ();
        axisOfRotation = (int) circularDrive.axisOfRotation;
        rotation = targetCrank.transform.rotation.eulerAngles[axisOfRotation];
        cycles = 0;
        maxRotation = circularDrive.maxAngle - circularDrive.minAngle;
    }

    // Update is called once per frame
    void Update()
    {
        oldRotation = rotation;
        rotation = targetCrank.transform.rotation.eulerAngles[axisOfRotation];
        CheckCycleIncrement();
        CheckCycleDecrement();
        ZoomCamera();
    }

    void CheckCycleIncrement() {
        if (rotation > 0 && rotation < 120 && oldRotation < 360 && oldRotation > 240) {
            cycles++;
        }
    }

    void CheckCycleDecrement() {
        if (rotation > 240 && rotation < 360 && oldRotation < 120 && oldRotation > 0) {
            cycles--;
        }
    }

    void ZoomCamera() {
        float calculatedRotation = (cycles * 360) + rotation;
        float calculatedFOV = ((-19 * calculatedRotation ) / (maxRotation / 3)) + 60;
        targetCamera.fieldOfView = calculatedFOV;
    }
}
