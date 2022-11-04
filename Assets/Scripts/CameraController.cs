using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float translationSmoothSpeed = 1f;
    [SerializeField] float rotationSmoothSpeed = 1f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, translationSmoothSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationSmoothSpeed * Time.deltaTime);
    }
}
