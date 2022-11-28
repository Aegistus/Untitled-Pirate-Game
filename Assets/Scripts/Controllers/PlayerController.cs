using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ShipMovement movement;
    ShipWeapons weapons;
    CameraController cameraController;
    ShipDirection aimDirection = ShipDirection.Prow;

    void Awake()
    {
        movement = GetComponent<ShipMovement>();
        weapons = GetComponent<ShipWeapons>();
        cameraController = FindObjectOfType<CameraController>();
    }

    void Update()
    {
        aimDirection = DeterminePlayerAimDirection();
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
            weapons.FireWeaponsOnSide(aimDirection);
        }
        movement.Turn(rotation);
        cameraController.Zoom(-Input.mouseScrollDelta.y);
    }

    RaycastHit rayHit;
    float[] directionAngles = new float[4];
    // Finds where the player is aiming as a ShipDirection based on where the mouse is.
    ShipDirection DeterminePlayerAimDirection()
    {
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, 1000f);
        ShipDirection direction = ShipDirection.Prow;
        Vector3 mousePos = rayHit.point;
        Vector3 mouseDir = mousePos - transform.position;
        directionAngles[0] = Vector3.SignedAngle(transform.forward, mouseDir, Vector3.up); // prow
        directionAngles[1] = Vector3.SignedAngle(-transform.forward, mouseDir, Vector3.up); // stern
        directionAngles[2] = Vector3.SignedAngle(transform.right, mouseDir, Vector3.up); // starboard
        directionAngles[3] = Vector3.SignedAngle(-transform.right, mouseDir, Vector3.up); // port
        // make all angles positive
        for (int i = 0; i < directionAngles.Length; i++)
        {
            directionAngles[i] = Mathf.Abs(directionAngles[i]);
        }
        float smallest = float.MaxValue;
        int smallestIndex = -1;
        for (int i = 0; i < directionAngles.Length; i++)
        {
            if (directionAngles[i] < smallest)
            {
                smallest = directionAngles[i];
                smallestIndex = i;
            }
        }
        direction = (ShipDirection)smallestIndex; // this casts the index to the relevant ShipDirection
        return direction;
    }
}
