using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float turnSpeed = 40;
    public float moveSpeed = 1.0f;
    float rotate;
    float move;
    float currentSpeed = 0f;

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
            currentSpeed += moveSpeed;
        }
    }

    public void DecreaseSpeed()
    {
        if (state != SailState.ANCHORED)
        {
            state--;
            currentSpeed -= moveSpeed;
        }
    }

    void Move()
    {
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime, Space.Self);
    }

    void Turn()
    {
        rotate = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Rotate(0f, rotate, 0f);
    }
}
