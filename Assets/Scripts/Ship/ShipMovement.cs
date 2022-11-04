using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float turnSpeed = 40;
    public float moveSpeed = 1.0f;
    public float acceleration = 1f;
    float rotate;
    float move;
    float currentSpeed = 0f;
    float targetSpeed = 0f;

    enum SailState {ANCHORED, HALF_SAIL, FULL_SAIL}
    SailState state;
    void Start()
    {
        state = SailState.ANCHORED;
    }

    void Update()
    {
        Move();
        Turn();
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

    void Turn()
    {
        rotate = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Rotate(0f, rotate, 0f);
    }
}
