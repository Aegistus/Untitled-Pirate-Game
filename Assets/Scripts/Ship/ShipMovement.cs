using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public enum SailState {ANCHORED, HALF_SAIL, FULL_SAIL}

    [Header("Turning")]
    // turn speed when at half sail.
    public float anchoredTurnSpeed = 40;
    public float halfSailTurnSpeed = 30;
    public float fullSailTurnSpeed = 20;
    public float turnAcceleration = .75f;
    public Vector3 turnPivot;

    [Header("Translation")]
    public float moveSpeed = 1.0f;
    public float acceleration = .4f;

    public SailState CurrentSailState => state;

    float currentSpeed = 0f;
    float targetSpeed = 0f;
    float currentTurnSpeed = 0f;
    float targetTurnSpeed = 0f;
    Vector3 currentTurnPivot;
    Vector3 targetTurnPivot;

    ShipParts shipParts;

    SoundManager sound;
    string furlSound = "Sails_Furl";
    string unfurlSound = "Sails_Unfurl";
    int furlSoundID;
    int unfurlSoundID;

    SailState state;

    ShipHealth status;

    void Start()
    {
        status = GameObject.FindObjectOfType<PlayerController>().GetComponent<ShipHealth>();
        shipParts = GetComponentInChildren<ShipParts>();
        sound = SoundManager.Instance;
        furlSoundID = sound.GetSoundID(furlSound);
        unfurlSoundID = sound.GetSoundID(unfurlSound);
        state = SailState.ANCHORED;
        currentTurnSpeed = anchoredTurnSpeed;
        UpdatePivot();
        UpdateTurnSpeed();
        UpdateSails(state);
    }

    void Update()
    {
        if (!status.HasSunk)
        {
            Move();
            currentTurnSpeed = Mathf.Lerp(currentTurnSpeed, targetTurnSpeed, turnAcceleration * Time.deltaTime);
            currentTurnPivot = Vector3.Lerp(currentTurnPivot, targetTurnPivot, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = 0f;
        }

    }

    public void IncreaseSpeed()
    {
        if (state != SailState.FULL_SAIL)
        {
            state++;
            targetSpeed += moveSpeed;
            UpdateTurnSpeed();
            UpdatePivot();
            sound.PlaySoundAtPosition(unfurlSoundID, transform.position);
            UpdateSails(state);
        }
    }

    public void DecreaseSpeed()
    {
        if (state != SailState.ANCHORED)
        {
            state--;
            targetSpeed -= moveSpeed;
            UpdateTurnSpeed();
            UpdatePivot();
            sound.PlaySoundAtPosition(furlSoundID, transform.position);
            UpdateSails(state);
        }
    }

    void Move()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime, Space.Self);
    }

    public void Turn(float rotationInput)
    {
        rotationInput = Mathf.Clamp(rotationInput, -1, 1);
        transform.RotateAround(transform.position + transform.TransformDirection(currentTurnPivot), Vector3.up, rotationInput * currentTurnSpeed * Time.deltaTime);
    }

    public void UpdateSails(SailState state)
    {
        if (state == SailState.ANCHORED)
        {
            SetChildrenActive(shipParts.ForeMast, shipParts.ForeFurled, false);
            SetChildrenActive(shipParts.MainMast, shipParts.MainFurled, false);
            SetChildrenActive(shipParts.MizzenMast, shipParts.MizzenFurled, false);

            // shipParts.MainMast.transform.GetChild(0).gameObject.SetActive(false);
            // shipParts.MainMast.transform.GetChild(1).gameObject.SetActive(false);
            // shipParts.ForeMast.transform.GetChild(0).gameObject.SetActive(false);
            // shipParts.ForeMast.transform.GetChild(1).gameObject.SetActive(false);
            // shipParts.MizzenMast.transform.GetChild(0).gameObject.SetActive(false);

            // shipParts.MainMast.transform.GetChild(2).gameObject.SetActive(true);
            // shipParts.ForeMast.transform.GetChild(2).gameObject.SetActive(true);
            // shipParts.MizzenMast.transform.GetChild(1).gameObject.SetActive(true);

            return;
        }
        if (state == SailState.HALF_SAIL)
        {
            SetChildrenActive(shipParts.ForeMast, shipParts.ForeFurled, false);
            SetChildrenActive(shipParts.MainMast, shipParts.MainFurled, true);
            SetChildrenActive(shipParts.MizzenMast, shipParts.MizzenFurled, false);
            // shipParts.MainMast.transform.GetChild(0).gameObject.SetActive(true);
            // shipParts.MainMast.transform.GetChild(1).gameObject.SetActive(false);
            // shipParts.ForeMast.transform.GetChild(0).gameObject.SetActive(false);
            // shipParts.ForeMast.transform.GetChild(1).gameObject.SetActive(false);
            // shipParts.MizzenMast.transform.GetChild(0).gameObject.SetActive(false);

            // shipParts.MainMast.transform.GetChild(2).gameObject.SetActive(false);
            // shipParts.ForeMast.transform.GetChild(2).gameObject.SetActive(true);
            // shipParts.MizzenMast.transform.GetChild(1).gameObject.SetActive(true);

            return;
        }
        if (state == SailState.FULL_SAIL)
        {
            SetChildrenActive(shipParts.ForeMast, shipParts.ForeFurled, true);
            SetChildrenActive(shipParts.MainMast, shipParts.MainFurled, true);
            SetChildrenActive(shipParts.MizzenMast, shipParts.MizzenFurled, true);
            // shipParts.MainMast.transform.GetChild(0).gameObject.SetActive(true);
            // shipParts.MainMast.transform.GetChild(1).gameObject.SetActive(true);
            // shipParts.ForeMast.transform.GetChild(0).gameObject.SetActive(true);
            // shipParts.ForeMast.transform.GetChild(1).gameObject.SetActive(true);
            // shipParts.MizzenMast.transform.GetChild(0).gameObject.SetActive(true);

            // shipParts.MainMast.transform.GetChild(2).gameObject.SetActive(false);
            // shipParts.ForeMast.transform.GetChild(2).gameObject.SetActive(false);
            // shipParts.MizzenMast.transform.GetChild(1).gameObject.SetActive(false);

            return;
        }
    }

    void UpdateTurnSpeed()
    {
        switch (state)
        {
            case SailState.ANCHORED: targetTurnSpeed = anchoredTurnSpeed;
            break;
            case SailState.HALF_SAIL: targetTurnSpeed = halfSailTurnSpeed;
            break;
            case SailState.FULL_SAIL: targetTurnSpeed = fullSailTurnSpeed;
            break;
        }
    }

    void UpdatePivot()
    {
        // if anchored, just rotate around the center of the ship
        if (state == SailState.ANCHORED)
        {
            targetTurnPivot = Vector3.zero;
        }
        else
        {
            targetTurnPivot = turnPivot;
        }
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.green;
    //     Gizmos.DrawSphere(transform.position + transform.TransformDirection(currentTurnPivot), 5f);
    // }
    public void AddToMovementSpeed(float speed)
    {
        moveSpeed += speed;
    }

    public void AddToTurnSpeed(float turnSpeed)
    {
        anchoredTurnSpeed += turnSpeed;
        halfSailTurnSpeed += turnSpeed;
        fullSailTurnSpeed += turnSpeed;
    }

    void SetChildrenActive(GameObject sail, GameObject furl, bool active)
    {
        for (int i = 0; i < sail.transform.childCount; i++)
        {
            sail.transform.GetChild(i).gameObject.SetActive(active);
        }
        for (int i = 0; i < furl.transform.childCount; i++)
        {
            furl.transform.GetChild(i).gameObject.SetActive(!active);
        }
    }
}
