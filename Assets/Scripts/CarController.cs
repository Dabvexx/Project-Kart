using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Found base code on Unity documentation on whele colliders
/// https://docs.unity3d.com/Manual/WheelColliderTutorial.html
/// </summary>
public class CarController : MonoBehaviour
{
    #region Variables

    // Variables.
    public List<AxleInfo> axleInfos; // the information about each individual axle

    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    #endregion Variables

    #region Private Methods

    // Private Methods.

    #endregion Private Methods

    #region Public Methods

    // Public Methods.
    public void Drive()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }

            ApplyLocalPositionToVisuals(axleInfo.leftWheel, axleInfo.visualLeft);
        }
    }

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider, Transform visualWheel)
    {
        if (visualWheel == null) return;

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    #endregion Public Methods
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public Transform visualLeft;
    public WheelCollider rightWheel;
    public Transform visualRight;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}