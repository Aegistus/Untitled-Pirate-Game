using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounty : MonoBehaviour
{
    public int goldGiven = 10;
    public PlayerGold gold;

    void Start()
    {
        ShipHealth health = GameObject.FindObjectOfType<PlayerController>().GetComponent<ShipHealth>();
        health.OnShipSink.AddListener (addGold);
    }

    public void addGold()
    {
        gold.AddGold (goldGiven);
    }
}