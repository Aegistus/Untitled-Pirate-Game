using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float translationSmoothSpeed = 1f;
    [SerializeField] float rotationSmoothSpeed = 1f;
    [SerializeField] float cursorFollowSpeed = 3f;
    [SerializeField] float maxCursorFollowDistance = 10f;

    bool followCursor = false;
    RaycastHit rayHit;

    void Update()
    {
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
}
