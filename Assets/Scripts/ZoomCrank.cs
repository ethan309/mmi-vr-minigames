using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;

public class ZoomCrank : MonoBehaviour
{

    public GameObject targetCamera;
    public GameObject targetCrank;
    private int axisOfRotation;
    public float rotation;
    public int cycles;
    private float oldRotation;

    // Start is called before the first frame update
    void Start()
    {
        CircularDrive circularDrive = targetCrank.GetComponent <CircularDrive> ();
        axisOfRotation = (int) circularDrive.axisOfRotation;
        rotation = targetCrank.transform.rotation.eulerAngles[axisOfRotation];
        cycles = 0;
    }

    // Update is called once per frame
    void Update()
    {
        oldRotation = rotation;
        rotation = targetCrank.transform.rotation.eulerAngles[axisOfRotation];
        CheckCycleIncrement();
        CheckCycleDecrement();

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

    }
}
