using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float rotateAngle;
    public float motorStrenght;
    public Wheel[] wheels;

    private Rigidbody _rb;
    private float horizontalInput;
    private float verticalInput;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
        Steering();
    }
    private void Move()
    {
        foreach(Wheel wheel in wheels)
        {
            if (wheel.isRear)
                wheel.collider.motorTorque = verticalInput * motorStrenght;


            
        }
    }

    private void Steering()
    {
        foreach (Wheel wheel in wheels)
        {
            if (wheel.isRear)
                continue;
            wheel.collider.steerAngle = rotateAngle * horizontalInput;

        }
    }
}

[Serializable]
public struct Wheel
{
    public WheelCollider collider;
    public Transform meshPozition;
    public bool isRear;
}
