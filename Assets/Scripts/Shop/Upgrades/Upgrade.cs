using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Upgrade
{
    public int goldCost;
    // how much the upgrade changes
    public int upgradeValue;
    
    public abstract void Apply();
}
