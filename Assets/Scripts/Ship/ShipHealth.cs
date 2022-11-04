using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public static readonly float waterIncreaseRate = .2f;

    public int BottomHealth { get; private set; }
    public int DeckHealth { get; private set; }
    public int SailHealth { get; private set; }

    public int MaxBottomHealth { get; private set; }
    public int MaxDeckHealth { get; private set; }
    public int MaxSailHealth { get; private set; }

    public float WaterLevel { get; private set; } = 0f;
    public float MaxWaterLevel { get; private set; } = 100f;
 
    void Awake()
    {
        BottomHealth = MaxBottomHealth;
        DeckHealth = MaxDeckHealth;
        SailHealth = MaxSailHealth;
        StartCoroutine(UpdateWaterLevel());
    }

    public void Damage(DamageValue damage)
    {
        BottomHealth -= damage.bottom;
        DeckHealth -= damage.deck;
        SailHealth -= damage.sails;
        ClampHealth();
    }

    public void Repair(RepairValue repair)
    {
        BottomHealth += repair.bottom;
        DeckHealth += repair.deck;
        SailHealth += repair.sails;
        ClampHealth();
    }

    void ClampHealth()
    {
        Mathf.Clamp(BottomHealth, 0, MaxBottomHealth);
        Mathf.Clamp(DeckHealth, 0, MaxDeckHealth);
        Mathf.Clamp(BottomHealth, 0, MaxBottomHealth);
    }

    IEnumerator UpdateWaterLevel()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            WaterLevel += MaxBottomHealth - BottomHealth * waterIncreaseRate;
            if (WaterLevel >= MaxWaterLevel)
            {
                Sink();
            }
        }
    }

    void Sink()
    {
        print(gameObject.name + " has sunk!");
    }
}
