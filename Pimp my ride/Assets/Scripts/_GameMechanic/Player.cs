using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float _moveInput;
    float _steerInput;

    public ControlMode control;
    CarController carController;

    void Start()
    {
        carController = GetComponent<CarController>();
    }

    void Update()
    {
        GetInputs();
    }

    void FixedUpdate()
    {
        carController.Move();
        carController.Steer();
        carController.Brake();
    }

    void GetInputs()
    {
        if (control == ControlMode.Keyboard)
        {
            _moveInput = Input.GetAxis("Vertical");
            _steerInput = Input.GetAxis("Horizontal");
            carController.SetDirection(_moveInput, _steerInput);
        }
    }
}
