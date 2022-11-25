using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<Upgrade> allUpgrades;
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
            // returns current upgrades to pool of all upgrades
            if (displayedUpgrades[i] != null)
            {
                allUpgrades.Add(displayedUpgrades[i]);
                displayedUpgrades[i] = null;
            }
            Upgrade u = allUpgrades[Random.Range(0, allUpgrades.Count)];
            displayedUpgrades[i] = u;
            allUpgrades.Remove(u);
        }
    }
}