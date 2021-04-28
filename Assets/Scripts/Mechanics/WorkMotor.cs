using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkMotor : MonoBehaviour, Device
{
    private HingeJoint joint;
    [SerializeField] [Range(.0f, 100.0f)] private float maxSpeed;
    [SerializeField] [Range(.0f, -100.0f)] private float minSpeed;
    private float force = 100.0f;
    private float currentSpeed = .0f;
    private void Start()
    {
        joint = GetComponent<HingeJoint>();
        joint.useMotor = true;
        JointMotor motor = joint.motor;
        motor.force = .0f;
        motor.targetVelocity = .0f;
        joint.motor = motor;
    }
    public void Work(float inputSignal)
    {
        var targetSpeed = inputSignal > .0f ? maxSpeed : inputSignal < 0 ? minSpeed : 0.0f;
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * 2);
        if (!joint.useMotor) joint.useMotor = true;
        JointMotor motor = joint.motor;
        motor.force = force;
        motor.targetVelocity = currentSpeed;
        motor.targetVelocity = Mathf.Clamp(motor.targetVelocity, minSpeed, maxSpeed);
        joint.motor = motor;
    }
}
