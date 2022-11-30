using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounty : MonoBehaviour
{
    public int goldGiven = 10;
    private PlayerGold playerGold;


    void Start()
    {
        ShipHealth health = GetComponent<ShipHealth>();
        playerGold = FindObjectOfType<PlayerGold>();
        health.OnShipSink.AddListener (addGold);
    }

    public void addGold()
    {
        playerGold.AddGold (goldGiven);
    }
}