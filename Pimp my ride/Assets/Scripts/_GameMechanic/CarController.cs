using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum ControlMode
{
    Keyboard,
    Buttons
};

public enum Axel
{
    Front,
    Rear
}

[Serializable]
public struct Wheel
{
    public GameObject wheelModel;
    public WheelCollider wheelCollider;
    public Axel axel;
}

public class CarController : MonoBehaviour
{

    [SerializeField] float _maxAcceleration = 30.0f;
    [SerializeField] float _brakeAcceleration = 50.0f;

    [SerializeField] float _turnSensitivity = 1.0f;
    [SerializeField] float _maxSteerAngle = 30.0f;

    [SerializeField] Vector3 _centerOfMass;

    [SerializeField] List<Wheel> wheels;

    private float _moveInput;
    private float _steerInput;

    private Rigidbody _carRb;

    void Start()
    {
        _carRb = GetComponent<Rigidbody>();
        _carRb.centerOfMass = _centerOfMass;
    }

    public void MoveInput(float input)
    {
        _moveInput = input;
    }

    public void SteerInput(float input)
    {
        _steerInput = input;
    }

    public void SetDirection(float moveInput, float steerInput)
    {
        _moveInput = moveInput;
        _steerInput = steerInput;
    }

    public void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = _moveInput * 600 * _maxAcceleration * Time.fixedDeltaTime;
        }
    }

    public void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = _steerInput * _turnSensitivity * _maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    public void Brake()
    {
        if (Input.GetKey(KeyCode.Space) || _moveInput == 0)
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 300 * _brakeAcceleration * Time.deltaTime;
            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }
    }

    public void SteeringToTarget(Vector3 target)
    {
        Vector3 relativeVector = transform.InverseTransformPoint(target);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * _maxAcceleration;
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
                wheel.wheelCollider.steerAngle = newSteer;
            wheel.wheelCollider.motorTorque = 10 * 600 * _maxAcceleration * Time.fixedDeltaTime;
        }
    }
}
