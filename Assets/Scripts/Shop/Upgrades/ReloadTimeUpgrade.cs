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
        ShipWeapons weapons = GameObject.FindObjectOfType<PlayerController>().GetComponent<ShipWeapons>();
        weapons.SubtractReloadTimeModifier(upgradeValue);
    }

    public override void IncreaseUpgradeLevel()
    {
        goldCost += 20;
    }

}
