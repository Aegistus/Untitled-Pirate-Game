using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ShipMovement movement;

    void Awake()
    {
        movement = GetComponent<ShipMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            movement.IncreaseSpeed();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movement.DecreaseSpeed();
        }
    }
}
