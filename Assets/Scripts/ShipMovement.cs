using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float turnSpeed = 40;
    public float moveSpeed = 1.0f;
    public float rotate;
    public float move;

    enum SailState {ANCHORED, HALF_SAIL, FULL_SAIL}
    SailState state;
    void Start()
    {
        state = SailState.ANCHORED;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            state = SailState.FULL_SAIL;
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            if (state == SailState.HALF_SAIL)
            {
                state = SailState.ANCHORED;
            }
            else if(state == SailState.FULL_SAIL)
                state = SailState.HALF_SAIL;
           
        }

        if(state == SailState.FULL_SAIL)
        {
            IncreaseSpeed();
            Turn();
        }
        else if(state == SailState.HALF_SAIL)
        {
            DecreaseSpeed();
            Turn();
        }
        else if(state == SailState.ANCHORED)
        {
            DecreaseSpeed();
        }
        
    }

    void IncreaseSpeed()
    {
        move = moveSpeed * Time.deltaTime;
        transform.Translate(0f,0f,move);
    }

    void DecreaseSpeed()
    {
        
        if(state == SailState.ANCHORED)
        {
            transform.Translate(transform.forward * 0 * Time.deltaTime);
        }
        else
        {
            move = moveSpeed/2 * Time.deltaTime;
            transform.Translate(0f, 0f, move);
        }
            
    }

    void Turn()
    {
        rotate = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Rotate(0f, rotate, 0f);
    }
}
