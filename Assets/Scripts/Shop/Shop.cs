using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<Upgrade> allUpgrades = new List<Upgrade>();
    // the max number of times certain upgrades can be purchased
    public int upgradePurchaseLimit = 3;
    [HideInInspector] public Upgrade[] displayedUpgrades = new Upgrade[3];

    void Start()
    {
        // add new upgrades here:
        allUpgrades.Add(new HealthUpgrade());

        ShuffleUpgrades();
    }

    // randomly selects 3 upgrades to display in the shop
    public void ShuffleUpgrades()
    {
        for (int i = 0; i < displayedUpgrades.Length; i++)
        {
            if (allUpgrades.Count == 0)
            {
                break;
            }
            // returns current upgrades to pool of all upgrades
            if (displayedUpgrades[i] != null)
            {
                allUpgrades.Add(displayedUpgrades[i]);
                displayedUpgrades[i] = null;
            }
            Upgrade upgrade = allUpgrades[Random.Range(0, allUpgrades.Count)];
            // displays only if the upgrade hasn't been purchased more than the limit
            if (upgrade.timesPurchased < upgradePurchaseLimit)
            {
                displayedUpgrades[i] = upgrade;
                allUpgrades.Remove(upgrade);
            }

        }
    }
}