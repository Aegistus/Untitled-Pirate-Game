using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairUpgrade : Upgrade
{
    public RepairUpgrade()
    {
        goldCost = 20;
    }
    public override void Apply()
    {
        PlayerGold gold = GameObject.FindObjectOfType<PlayerGold>();
        if (gold.TrySpendGold(goldCost))
        {
            ShipHealth health = GameObject.FindObjectOfType<PlayerController>().GetComponent<ShipHealth>();
            health.RepairAll();
            //IncreaseUpgradeLevel();
        }
        else
            Debug.Log("Not enough gold for health");
    }

    public override void IncreaseUpgradeLevel()
    {
        throw new System.NotImplementedException();
    }
}
