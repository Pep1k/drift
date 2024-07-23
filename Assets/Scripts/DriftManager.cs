using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftManager : MonoBehaviour
{
    public float apeedThreshhold;
    public float driftStartAngle;
    public bool isDrifting;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CalculateDrift();
    }

    private void CalculateDrift()
    {
        if (_rb.velocity.magnitude < apeedThreshhold)
            return;

        var vec1 = _rb.velocity;
        var vec2 = transform.forward;
        var angle = Vector3.Angle(vec1, vec2);
        if (angle > driftStartAngle && angle < 90)
        {
            isDrifting = true;
        }
        else
        {
            isDrifting= false;
        }
    }
}
