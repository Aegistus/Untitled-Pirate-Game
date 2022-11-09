using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ShipMovement movement;
    ShipWeapons weapons;
    CameraController cameraController;

    void Awake()
    {
        movement = GetComponent<ShipMovement>();
        weapons = GetComponent<ShipWeapons>();
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
        float rotation = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            weapons.FireWeaponsOnSide(ShipDirection.Starboard);
            weapons.FireWeaponsOnSide(ShipDirection.Port);
        }
        movement.Turn(rotation);
        cameraController.Zoom(-Input.mouseScrollDelta.y);
    }
}
