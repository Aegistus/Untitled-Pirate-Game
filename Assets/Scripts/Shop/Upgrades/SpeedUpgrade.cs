using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : Upgrade
{
    public SpeedUpgrade()
    {
        goldCost = 10;
        upgradeValue = 1f;
        upgradeName = "Speed Upgrade";
        description = "Increase ship speed by " + upgradeValue + ".";
    }
    public override void Apply()
    {
        ShipMovement speed = GameObject.FindObjectOfType<PlayerController>().GetComponent<ShipMovement>();
        speed.AddToMovementSpeed((int)upgradeValue);
    }

    public override void IncreaseUpgradeLevel()
    {
        goldCost += 20;
        upgradeValue += 1;
    }
}
