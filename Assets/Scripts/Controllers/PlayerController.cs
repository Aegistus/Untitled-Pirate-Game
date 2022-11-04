using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ShipMovement movement;
    CameraController cameraController;

    void Awake()
    {
        movement = GetComponent<ShipMovement>();
        cameraController = FindObjectOfType<CameraController>();
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
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            cameraController.FollowCursor(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            cameraController.FollowCursor(false);
        }
    }
}
