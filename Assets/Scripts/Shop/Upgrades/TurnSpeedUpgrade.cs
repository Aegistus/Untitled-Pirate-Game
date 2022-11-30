using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSpeedUpgrade : Upgrade
{
    public TurnSpeedUpgrade()
    {
        goldCost = 10;
        upgradeValue = 10f;
        upgradeName = "Turn Speed Upgrade";
        description = "Increase turn speed by " + upgradeValue + ".";
    }
    public override void Apply()
    {
        ShipMovement shipMovement = GameObject.FindObjectOfType<PlayerController>().GetComponent<ShipMovement>();
        shipMovement.AddToTurnSpeed(upgradeValue);
    }

    public override void IncreaseUpgradeLevel()
    {
        goldCost += 20;
        upgradeValue += 10f;
        description = "Increase turn speed by " + upgradeValue + ".";
        timesPurchased++;
    }
}
