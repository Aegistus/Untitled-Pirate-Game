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
        ShipWeapons damage = GameObject.FindObjectOfType<PlayerController>().GetComponent<ShipWeapons>();
        damage.AddToDamageModifier(upgradeValue);
    }

    public override void IncreaseUpgradeLevel()
    {
        goldCost += 20;
        upgradeValue += .1f;
    }
}
