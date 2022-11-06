using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public enum SailState {ANCHORED, HALF_SAIL, FULL_SAIL}

    public float turnSpeed = 40;
    public float moveSpeed = 1.0f;
    public float acceleration = 1f;

    public SailState CurrentSailState => state;

    float currentSpeed = 0f;
    float targetSpeed = 0f;

    SailState state;
    void Start()
    {
        state = SailState.ANCHORED;
    }

    void Update()
    {
        Move();
    }

    public void IncreaseSpeed()
    {
        if (state != SailState.FULL_SAIL)
        {
            state++;
            targetSpeed += moveSpeed;
        }
    }

    public void DecreaseSpeed()
    {
        if (state != SailState.ANCHORED)
        {
            state--;
            targetSpeed -= moveSpeed;
        }
    }

    void Move()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime, Space.Self);
    }

    public void Turn(float rotation)
    {
        rotation = Mathf.Clamp(rotation, -1, 1);
        transform.Rotate(0f, rotation * turnSpeed * Time.deltaTime, 0f);
    }
}
