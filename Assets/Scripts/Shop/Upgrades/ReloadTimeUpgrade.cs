using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadTimeUpgrade : Upgrade
{

    public ReloadTimeUpgrade()
    {
        goldCost = 10;
        upgradeValue = .1f;
        upgradeName = "Reload Time Upgrade";
        description = "Decrease cannon reload time by " + upgradeValue + ".";
    }
    public override void Apply()
    {
        PlayerGold gold = GameObject.FindObjectOfType<PlayerGold>();
        if (gold.TrySpendGold(goldCost))
        {
            ShipWeapons weapons = GameObject.FindObjectOfType<PlayerController>().GetComponent<ShipWeapons>();
            weapons.SubtractReloadTimeModifier(upgradeValue);
            IncreaseUpgradeLevel();
        }
        else
            Debug.Log("Not enough gold for reload time");
    }

    public override void IncreaseUpgradeLevel()
    {
        goldCost += 20;
        timesPurchased++;
    }

}
