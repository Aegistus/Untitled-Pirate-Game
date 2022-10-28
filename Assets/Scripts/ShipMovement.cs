using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float turnSpeed = 1000f;
    public float accelerateSpeed = 1000f;

    private Rigidbody rbody;
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rbody.AddTorque(0f, h * turnSpeed * Time.deltaTime, 0f);
        rbody.AddForce(transform.forward * v * accelerateSpeed * Time.deltaTime);
    }

    void IncreaseSpeed()
    {

    }

    void DecreaseSpeed()
    {

    }

    void Turn()
    {
       
    }
}
