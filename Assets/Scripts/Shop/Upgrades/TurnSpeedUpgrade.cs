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
        PlayerGold gold = GameObject.FindObjectOfType<PlayerGold>();
        if (gold.TrySpendGold(goldCost))
        {
            ShipMovement shipMovement = GameObject.FindObjectOfType<PlayerController>().GetComponent<ShipMovement>();
            shipMovement.AddToTurnSpeed(upgradeValue);
            IncreaseUpgradeLevel();
        }
        else
            Debug.Log("Not enough gold for turn speed");
    }

    public override void IncreaseUpgradeLevel()
    {
        goldCost += 20;
        upgradeValue += 10f;
        description = "Increase turn speed by " + upgradeValue + ".";
        timesPurchased++;
    }
}
