using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public enum SailState {ANCHORED, HALF_SAIL, FULL_SAIL}

    // turn speed when at half sail.
    public float anchoredTurnSpeed = 40;
    public float halfSailTurnSpeed = 30;
    public float fullSailTurnSpeed = 20;

    public float moveSpeed = 1.0f;
    public float acceleration = 1f;

    public SailState CurrentSailState => state;

    float currentSpeed = 0f;
    float targetSpeed = 0f;
    float currentTurnSpeed = 0f;

    ShipParts shipParts;

    SoundManager sound;
    string furlSound = "Sails_Furl";
    string unfurlSound = "Sails_Unfurl";
    int furlSoundID;
    int unfurlSoundID;

    SailState state;
    void Start()
    {
        shipParts = GetComponentInChildren<ShipParts>();
        sound = SoundManager.Instance;
        furlSoundID = sound.GetSoundID(furlSound);
        unfurlSoundID = sound.GetSoundID(unfurlSound);
        state = SailState.ANCHORED;
        currentTurnSpeed = anchoredTurnSpeed;
        UpdateSails();
    }

    void Update()
    {
        Move();
    }

    public void IncreaseSpeed()
    {
        if (state != SailState.FULL_SAIL)
        {
            state++;
            targetSpeed += moveSpeed;
            UpdateTurnSpeed();
            sound.PlaySoundAtPosition(unfurlSoundID, transform.position);
            UpdateSails();
        }
    }

    public void DecreaseSpeed()
    {
        if (state != SailState.ANCHORED)
        {
            state--;
            targetSpeed -= moveSpeed;
            UpdateTurnSpeed();
            sound.PlaySoundAtPosition(furlSoundID, transform.position);
            UpdateSails();
        }
    }

    void Move()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime, Space.Self);
    }

    public void Turn(float rotation)
    {
        rotation = Mathf.Clamp(rotation, -1, 1);
        transform.Rotate(0f, rotation * currentTurnSpeed * Time.deltaTime, 0f);
    }

    void UpdateSails()
    {
        if (state == SailState.ANCHORED)
        {
            shipParts.MainMast.transform.GetChild(0).gameObject.SetActive(false);
            shipParts.ForeMast.transform.GetChild(0).gameObject.SetActive(false);
            shipParts.MizzenMast.transform.GetChild(0).gameObject.SetActive(false);
            return;
        }
        if (state == SailState.HALF_SAIL)
        {
            shipParts.MainMast.transform.GetChild(0).gameObject.SetActive(true);
            shipParts.ForeMast.transform.GetChild(0).gameObject.SetActive(false);
            shipParts.MizzenMast.transform.GetChild(0).gameObject.SetActive(false);
            return;
        }
        if (state == SailState.FULL_SAIL)
        {
            shipParts.MainMast.transform.GetChild(0).gameObject.SetActive(true);
            shipParts.ForeMast.transform.GetChild(0).gameObject.SetActive(true);
            shipParts.MizzenMast.transform.GetChild(0).gameObject.SetActive(true);
            return;
        }
    }

    void UpdateTurnSpeed()
    {
        switch (state)
        {
            case SailState.ANCHORED: currentTurnSpeed = anchoredTurnSpeed;
            break;
            case SailState.HALF_SAIL: currentTurnSpeed = halfSailTurnSpeed;
            break;
            case SailState.FULL_SAIL: currentTurnSpeed = fullSailTurnSpeed;
            break;
        }
    }
}
