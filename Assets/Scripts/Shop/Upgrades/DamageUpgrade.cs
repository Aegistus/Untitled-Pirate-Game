using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade : Upgrade
{
    public DamageUpgrade()
    {
        goldCost = 10;
        upgradeValue = .1f;
        upgradeName = "Damage Upgrade";
        description = "Increase damage by " + upgradeValue + ".";
    }
    public override void Apply()
    {
        PlayerGold gold = GameObject.FindObjectOfType<PlayerGold>();
        if (gold.TrySpendGold(goldCost))
        {
            ShipWeapons damage = GameObject.FindObjectOfType<PlayerController>().GetComponent<ShipWeapons>();
            damage.AddToDamageModifier(upgradeValue);
            IncreaseUpgradeLevel();
        }
        else
            Debug.Log("Not enough gold for damage");
    }

    public override void IncreaseUpgradeLevel()
    {
        goldCost += 20;
        upgradeValue += .1f;
        description = "Increase damage by " + upgradeValue + ".";
    }
}
