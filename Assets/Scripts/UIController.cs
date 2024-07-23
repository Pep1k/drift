using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TMP_Text speedometerText;

    public WheelCollider leftWheel;
    public WheelCollider rightWheel;

    public float Speedometer()
    {
        float firstRPM = leftWheel.rpm;
        float secondRPM = rightWheel.rpm;
        float totalRPM = (firstRPM + secondRPM) / 2;
        float speed = totalRPM * leftWheel.radius * 2 * Mathf.PI * 60 / 1000;
        return Mathf.Round(speed * 10.0f) * 0.1f;

    }
    private void Update()
    {
        speedometerText.text = Speedometer().ToString();
    }
}
