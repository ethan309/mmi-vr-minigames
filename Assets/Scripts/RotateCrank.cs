using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;

public class RotateCrank : MonoBehaviour
{
    public GameObject targetRotatable;
    public GameObject targetCrank;
    public float rotationScale;

    private int axisOfRotation;
    private float maxRotation;
    private float rotation;
    private int cycles;
    private float oldRotation;
    private int oldCycles;
    private bool incrementFlag;
    private bool decrementFlag;

    // Start is called before the first frame update
    void Start()
    {
        CircularDrive circularDrive = targetCrank.GetComponent <CircularDrive> ();
        axisOfRotation = (int) circularDrive.axisOfRotation;
        rotation = targetCrank.transform.rotation.eulerAngles[axisOfRotation];
        cycles = 0;
        oldCycles = 0;
        maxRotation = circularDrive.maxAngle - circularDrive.minAngle;
        if (rotationScale == 0) {
            rotationScale = 1;
        }
        incrementFlag = false;
        decrementFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        oldRotation = rotation;
        rotation = targetCrank.transform.rotation.eulerAngles[axisOfRotation];
        CheckCycleIncrement();
        CheckCycleDecrement();
        RotateObject();
    }

    void CheckCycleIncrement() {
        if (incrementFlag) {
            oldCycles++;
            incrementFlag = false;
        }
        if (rotation > 0 && rotation < 120 && oldRotation < 360 && oldRotation > 240) {
            cycles++;
            incrementFlag = true;
        }
    }

    void CheckCycleDecrement() {
        if (decrementFlag) {
            oldCycles--;
            decrementFlag = false;
        }
        if (rotation > 240 && rotation < 360 && oldRotation < 120 && oldRotation > 0) {
            cycles--;
            decrementFlag = true;
        }
    }

    void RotateObject() {
        float calculatedRotation = (cycles * 360) + rotation;
        float calculatedOldRotation = (oldCycles * 360) + oldRotation;
        float calculatedChangeInRotation = calculatedRotation - calculatedOldRotation;
        targetRotatable.transform.Rotate(0, calculatedChangeInRotation / rotationScale, 0);
        RotateSkybox();
    }

    void RotateSkybox() {
        RenderSettings.skybox.SetFloat("_Rotation", targetRotatable.transform.rotation.eulerAngles[axisOfRotation]);
    }
}
