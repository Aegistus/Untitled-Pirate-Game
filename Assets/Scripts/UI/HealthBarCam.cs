using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarCam : MonoBehaviour
{
    Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.LookAt(cam.position);
        transform.localEulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
    }
}