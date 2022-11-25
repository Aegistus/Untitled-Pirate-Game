using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : Upgrade
{
    public override void Apply()
    {
        ShipHealth health = GameObject.FindObjectOfType<PlayerController>().GetComponent<ShipHealth>();
        health.AddToMaxHealth(upgradeValue);
    }
}
