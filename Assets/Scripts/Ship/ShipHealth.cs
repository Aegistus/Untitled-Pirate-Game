using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipHealth : MonoBehaviour
{
    public UnityEvent OnHealthChange;
    public UnityEvent OnWaterLevelChange;
    public static readonly float waterIncreaseRate = .02f;

    public int BottomHealth { get; private set; }
    public int DeckHealth { get; private set; }
    public int SailHealth { get; private set; }

    public int MaxBottomHealth { get; private set; } = 1000;
    public int MaxDeckHealth { get; private set; } = 1000;
    public int MaxSailHealth { get; private set; } = 1000;

    public float WaterLevel { get; private set; } = 0f;
    public float MaxWaterLevel { get; private set; } = 1000f;
 
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
        OnHealthChange.Invoke();
    }

    public void Repair(RepairValue repair)
    {
        BottomHealth += repair.bottom;
        DeckHealth += repair.deck;
        SailHealth += repair.sails;
        ClampHealth();
        OnHealthChange.Invoke();
    }

    void ClampHealth()
    {
        BottomHealth = Mathf.Clamp(BottomHealth, 0, MaxBottomHealth);
        DeckHealth = Mathf.Clamp(DeckHealth, 0, MaxDeckHealth);
        SailHealth = Mathf.Clamp(SailHealth, 0, MaxSailHealth);
    }

    IEnumerator UpdateWaterLevel()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            WaterLevel += (MaxBottomHealth - BottomHealth) * waterIncreaseRate;
            OnWaterLevelChange.Invoke();
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
