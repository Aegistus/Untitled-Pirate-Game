using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounty : MonoBehaviour
{
    public int goldGiven = 0;
    
    void Start()
    {
        ShipHealth health = GameObject.FindObjectOfType<PlayerController>().GetComponent<ShipHealth>();
        health.OnShipSink.AddListener(addGold);
    }
    public void addGold()
    {
        PlayerGold gold = new PlayerGold();
        gold.AddGold(goldGiven);
    }
}
