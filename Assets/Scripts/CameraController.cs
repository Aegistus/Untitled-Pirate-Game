using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [Header("Movement")]
    [SerializeField] float translationSmoothSpeed = 1f;
    [SerializeField] float rotationSmoothSpeed = 1f;
    [SerializeField] float cursorFollowSpeed = 3f;
    [SerializeField] float maxCursorFollowDistance = 10f;
    [Header("Zoom")]
    [SerializeField] float zoomIncrement = 10f;
    [SerializeField] float zoomSpeed = 5f;
    [SerializeField] float minZoom = 20f;
    [SerializeField] float maxZoom = 200f;
        
    float targetZoom;
    bool followCursor = false;
    RaycastHit rayHit;

    void Awake()
    {
        if (target == null)
        {
            target = FindObjectOfType<PlayerController>().transform;
        }
        targetZoom = transform.position.y;
    }

    void Update()
    {
        float y = Mathf.Lerp(transform.position.y, targetZoom, zoomSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        // if in free cam mode
        if (followCursor)
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, 1000f);
            Vector3 cursorPosition = rayHit.point;
            cursorPosition.y = target.position.y;
            float distance = Vector3.Distance(cursorPosition, target.position);
            // clamp if greater than max distance
            if (distance > maxCursorFollowDistance)
            {
                cursorPosition = target.InverseTransformPoint(cursorPosition);
                cursorPosition = Vector3.ClampMagnitude(cursorPosition, maxCursorFollowDistance);
                cursorPosition = target.TransformPoint(cursorPosition);
            }
            transform.position = Vector3.Lerp(transform.position, cursorPosition, cursorFollowSpeed * Time.deltaTime);
        }
        // if in not-free cam mode
        else
        {
            transform.position = Vector3.Lerp(transform.position, target.position, translationSmoothSpeed * Time.deltaTime);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationSmoothSpeed * Time.deltaTime);
    }

    public void FollowCursor(bool follow)
    {
        followCursor = follow;
    }

    public void Zoom(float amount)
    {
        targetZoom += amount * zoomIncrement;
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
    }
}
