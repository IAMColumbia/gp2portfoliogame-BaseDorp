using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script referenced from https://gamedev.stackexchange.com/questions/118388/how-to-do-an-anti-sway-bar-for-a-car-in-unity-5
/// </summary>

public class AntiRollBar : MonoBehaviour
{
    //[SerializeField]
    //WheelCollider LeftWheel;
    //[SerializeField]
    //WheelCollider RightWheel;
    //[SerializeField]
    //float antiRoll = 50000f;

    //private Rigidbody carRigidBody;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    carRigidBody = GetComponent<Rigidbody>();
    //}

    //private void FixedUpdate()
    //{
    //    WheelHit hit = new WheelHit();
    //    float travelLeft = 1.0f;
    //    float travelRight = 1.0f;

    //    bool groundedLeft = LeftWheel.GetGroundHit(out hit);
    //    bool groundedRight = RightWheel.GetGroundHit(out hit);

    //    if (groundedLeft)
    //    {
    //        travelLeft = (-LeftWheel.transform.InverseTransformPoint(hit.point).y - LeftWheel.radius) / LeftWheel.suspensionDistance;
    //    }

    //    if (groundedRight)
    //    {
    //        travelRight = (-RightWheel.transform.InverseTransformPoint(hit.point).y - LeftWheel.radius) / LeftWheel.suspensionDistance;
    //    }

    //    float antiRollForce = (travelLeft - travelRight) * antiRoll;

    //    if (groundedLeft)
    //    {
    //        carRigidBody.AddForceAtPosition(LeftWheel.transform.up * -antiRollForce, LeftWheel.transform.position);
    //    }

    //    if (groundedRight)
    //    {
    //        carRigidBody.AddForceAtPosition(RightWheel.transform.up * -antiRollForce, RightWheel.transform.position);
    //    }
    //}

    public WheelCollider WheelL;
    public WheelCollider WheelR;
    private Rigidbody rb;

    public float AntiRoll = 5000.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        WheelHit hit = new WheelHit();
        float travelL = 1.0f;
        float travelR = 1.0f;

        bool groundedL = WheelL.GetGroundHit(out hit);

        if (groundedL)
        {
            travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y
                    - WheelL.radius) / WheelL.suspensionDistance;
        }

        bool groundedR = WheelR.GetGroundHit(out hit);

        if (groundedR)
        {
            travelR = (-WheelR.transform.InverseTransformPoint(hit.point).y
                    - WheelR.radius) / WheelR.suspensionDistance;
        }

        var antiRollForce = (travelL - travelR) * AntiRoll;

        if (groundedL)
            rb.AddForceAtPosition(WheelL.transform.up * -antiRollForce,
                WheelL.transform.position);
        if (groundedR)
            rb.AddForceAtPosition(WheelR.transform.up * antiRollForce,
                WheelR.transform.position);
    }
}
