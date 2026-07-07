using UnityEngine;
using System.Collections.Generic;

public class VehicleController : MonoBehaviour
{
    public InputController InputCtrl;
    [Tooltip("Set ref in order of FL, FR, RL, RR")]
    public WheelCollider[] WheelColliders;
    [Tooltip("Set ref of wheel meshes in order of  FL, FR, RL, RR")]
    public Transform[] Wheels;
    public Transform CenterOfMass;
    public float MaxMotorTorque = 500f;
    public float MaxSteeringAngle = 30f;
    public float BrakeForce = 300f;

    [Header("Suspension Settings")]
    public float SuspensionDistance = 0.2f;
    public float SpringForce = 35000f;
    public float DamperForce = 4500f;
    public float TargetPosition = 0.5f;

    [Header("Friction Settings")]
    public float ForwardFriction = 1.5f;
    public float SidewaysFriction = 1.5f;
    public float ForwardExtremumSlip = 0.4f;
    public float SidewaysExtremumSlip = 0.2f;

    [Header("Stability Settings")]
    public float AntiRollForce = 5000f;
    public float DownforceCoefficient = 1f;
    public float TractionControlStrength = 0.5f;
    public float MaxSpeedKMH = 200f;

    private Rigidbody rb;
    private float currentMotorTorque;
    private float currentSteeringAngle;
    private List<WheelData> wheelDataList = new List<WheelData>();

    private class WheelData
    {
        public WheelCollider Collider;
        public float SlipRatio;
        public float PrevAngularVelocity;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = CenterOfMass.localPosition;

        foreach (WheelCollider wheel in WheelColliders)
        {
            SetupWheelCollider(wheel);
            wheelDataList.Add(new WheelData { Collider = wheel, SlipRatio = 0f, PrevAngularVelocity = 0f });
        }
    }

    private void SetupWheelCollider(WheelCollider wheel)
    {
        wheel.suspensionDistance = SuspensionDistance;
        JointSpring spring = wheel.suspensionSpring;
        spring.spring = SpringForce;
        spring.damper = DamperForce;
        spring.targetPosition = TargetPosition;
        wheel.suspensionSpring = spring;

        WheelFrictionCurve forwardFriction = wheel.forwardFriction;
        forwardFriction.stiffness = ForwardFriction;
        forwardFriction.extremumSlip = ForwardExtremumSlip;
        wheel.forwardFriction = forwardFriction;

        WheelFrictionCurve sidewaysFriction = wheel.sidewaysFriction;
        sidewaysFriction.stiffness = SidewaysFriction;
        sidewaysFriction.extremumSlip = SidewaysExtremumSlip;
        wheel.sidewaysFriction = sidewaysFriction;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < WheelColliders.Length; i++)
        {
            
        }
        UpdateWheelData();
        UpdateWheelMovements();
        LimitTopSpeed();
        ApplyAntiRollForce();
        ApplyDownforce();
        Drive();
        Steer();
        Brake();
    }

    private void LimitTopSpeed()
    {
        float maxSpeedMS = MaxSpeedKMH / 3.6f;
        if (rb.velocity.magnitude > maxSpeedMS)
        {
            rb.velocity = rb.velocity.normalized * maxSpeedMS;
        }
    }

    private void UpdateWheelData()
    {
        for (int i = 0; i < wheelDataList.Count; i++)
        {
            WheelData data = wheelDataList[i];
            WheelHit hit;
            if (data.Collider.GetGroundHit(out hit))
            {
                float angularVelocity = data.Collider.rpm * 2f * Mathf.PI / 60f;
                float wheelLinearVelocity = angularVelocity * data.Collider.radius;
                data.SlipRatio = (wheelLinearVelocity - hit.forwardSlip) / Mathf.Max(Mathf.Abs(wheelLinearVelocity), Mathf.Abs(hit.forwardSlip), 0.1f);
            }
            else
            {
                data.SlipRatio = 0f;
            }
            data.PrevAngularVelocity = data.Collider.rpm * 2f * Mathf.PI / 60f;
        }
    }

    private void ApplyAntiRollForce()
    {
        ApplyAntiRoll(WheelColliders[0], WheelColliders[1]); // Front
        ApplyAntiRoll(WheelColliders[2], WheelColliders[3]); // Rear
    }

    private void ApplyAntiRoll(WheelCollider wheelL, WheelCollider wheelR)
    {
        WheelHit hitL, hitR;
        float travelL = 1.0f;
        float travelR = 1.0f;

        bool groundedL = wheelL.GetGroundHit(out hitL);
        bool groundedR = wheelR.GetGroundHit(out hitR);

        if (groundedL)
            travelL = (-wheelL.transform.InverseTransformPoint(hitL.point).y - wheelL.radius) / wheelL.suspensionDistance;
        if (groundedR)
            travelR = (-wheelR.transform.InverseTransformPoint(hitR.point).y - wheelR.radius) / wheelR.suspensionDistance;

        float antiRollForce = (travelL - travelR) * AntiRollForce;

        if (groundedL)
            rb.AddForceAtPosition(wheelL.transform.up * -antiRollForce, wheelL.transform.position);
        if (groundedR)
            rb.AddForceAtPosition(wheelR.transform.up * antiRollForce, wheelR.transform.position);
    }

    private void ApplyDownforce()
    {
        float speed = rb.velocity.magnitude;
        float downforce = DownforceCoefficient * speed * speed;
        rb.AddForce(-transform.up * downforce);
    }

    private void Drive()
    {
        float targetMotorTorque = InputCtrl.Vertical * MaxMotorTorque;
        currentMotorTorque = Mathf.Lerp(currentMotorTorque, targetMotorTorque, Time.fixedDeltaTime * 5f);

        for (int i = 2; i < 4; i++) // Apply drive force to rear wheels only
        {
            float adjustedTorque = ApplyTractionControl(currentMotorTorque, wheelDataList[i]);
            WheelColliders[i].motorTorque = adjustedTorque;
            AdjustWheelFriction(WheelColliders[i], wheelDataList[i]);
        }
    }

    private float ApplyTractionControl(float torque, WheelData wheelData)
    {
        float slipThreshold = 0.2f;
        if (Mathf.Abs(wheelData.SlipRatio) > slipThreshold)
        {
            return torque * (1f - TractionControlStrength);
        }
        return torque;
    }

    private void AdjustWheelFriction(WheelCollider wheel, WheelData wheelData)
    {
        WheelHit hit;
        if (wheel.GetGroundHit(out hit))
        {
            float slipFactor = Mathf.Clamp01(1 - Mathf.Abs(wheelData.SlipRatio));
            float loadFactor = hit.force / wheel.sprungMass;

            WheelFrictionCurve fwdFriction = wheel.forwardFriction;
            fwdFriction.stiffness = Mathf.Lerp(ForwardFriction * 0.5f, ForwardFriction * 1.5f, slipFactor * loadFactor);
            wheel.forwardFriction = fwdFriction;

            WheelFrictionCurve sideFriction = wheel.sidewaysFriction;
            sideFriction.stiffness = Mathf.Lerp(SidewaysFriction * 0.5f, SidewaysFriction * 1.5f, slipFactor * loadFactor);
            wheel.sidewaysFriction = sideFriction;
        }
    }

    private void Steer()
    {
        //if (InputCtrl.Horizontal == 1f || InputCtrl.Horizontal == -1f)
        //{
            float targetSteeringAngle = InputCtrl.Horizontal * MaxSteeringAngle;
            currentSteeringAngle = Mathf.Lerp(currentSteeringAngle, targetSteeringAngle, Time.fixedDeltaTime * 5f);

            // Apply steering to front wheels
            WheelColliders[0].steerAngle = currentSteeringAngle;
            WheelColliders[1].steerAngle = currentSteeringAngle;
        }
    //}

    private void Brake()
    {
        float brakeTorque = InputCtrl.Brake * BrakeForce;
        for (int i = 0; i < WheelColliders.Length; i++)
        {
            WheelColliders[i].brakeTorque = brakeTorque;
        }
    }

    private void UpdateWheelMovements()
    {
        for (var i = 0; i < Wheels.Length; i++)
        {
            Vector3 pos;
            Quaternion rot;
            WheelColliders[i].GetWorldPose(out pos, out rot);
            Wheels[i].transform.position = pos;
            Wheels[i].transform.rotation = rot;
        }
    }
}