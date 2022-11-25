using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade
{
    // how much the upgrade costs
    public int goldCost;
    // how much the upgrade changes (ex: +10% damage would mean upgradeValue = .1)
    public float upgradeValue;
    // name for UI
    public string upgradeName;
    // description for UI
    public string description;
    
    // Applies the upgrade to the player's ship
    public abstract void Apply();

    // Increases the cost and the stats given.
    public abstract void IncreaseUpgradeLevel();
}
