using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : Upgrade
{
    public HealthUpgrade()
    {
        goldCost = 10;
        upgradeValue = 100f;
        upgradeName = "Health Upgrade";
        description = "Increase ship health by " + upgradeValue + ".";
    }

    public override void Apply()
    {
        ShipHealth health = GameObject.FindObjectOfType<PlayerController>().GetComponent<ShipHealth>();
        health.AddToMaxHealth((int)upgradeValue);
    }

    public override void IncreaseUpgradeLevel()
    {
        goldCost += 20;
        upgradeValue += 100;
    }
}
