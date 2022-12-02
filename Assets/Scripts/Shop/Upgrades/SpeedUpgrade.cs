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
        PlayerGold gold = GameObject.FindObjectOfType<PlayerGold>();
        if (gold.TrySpendGold(goldCost))
        {
            ShipMovement shipMovement = GameObject.FindObjectOfType<PlayerController>().GetComponent<ShipMovement>();
            shipMovement.AddToMovementSpeed(upgradeValue);
            IncreaseUpgradeLevel();
        }
        else
            Debug.Log("Not enough gold for speed");
    }

    public override void IncreaseUpgradeLevel()
    {
        goldCost += 20;
        upgradeValue += 1;
        description = "Increase ship speed by " + upgradeValue + ".";
        timesPurchased++;
    }
}
