using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadTimeUpgrade : Upgrade
{

    public ReloadTimeUpgrade()
    {
        goldCost = 10;
        upgradeValue = .5f;
        upgradeName = "Reload Time Upgrade";
        description = "Increase cannon reload time by " + upgradeValue + ".";
    }
    public override void Apply()
    {
        CannonController time = GameObject.FindObjectOfType<PlayerController>().GetComponent<CannonController>();
        time.decreaseReloadTime(upgradeValue);
    }

    public override void IncreaseUpgradeLevel()
    {
        goldCost += 20;
    }

}
