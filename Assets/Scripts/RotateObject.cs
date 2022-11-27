using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RotateObject : MonoBehaviour
{
    public Transform objectToRotate;
    public float rotationSpeed = 1f;

    void Update()
    {
        if (objectToRotate != null)
        {
            objectToRotate.Rotate(Vector3.up * rotationSpeed, Space.World);
        }
    }
}
