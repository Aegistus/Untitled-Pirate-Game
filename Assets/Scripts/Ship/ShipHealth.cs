using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipHealth : MonoBehaviour
{
    public UnityEvent OnHealthChange;
    public UnityEvent OnWaterLevelChange;
    public UnityEvent OnShipSink;
    public static readonly float waterIncreaseRate = .02f;
    public static readonly float waterDecreaseRate = .4f;

    [SerializeField] public int maxBottomHealth = 1000;
    [SerializeField] public int maxDeckHealth = 1000;
    [SerializeField] public int maxSailHealth = 1000;

    public int BottomHealth { get; private set; }
    public int DeckHealth { get; private set; }
    public int SailHealth { get; private set; }

    public float WaterLevel { get; private set; } = 0f;
    public float MaxWaterLevel { get; private set; } = 1000f;

    public bool HasSunk { get; private set; } = false;

    void Awake()
    {
        BottomHealth = maxBottomHealth;
        DeckHealth = maxDeckHealth;
        SailHealth = maxSailHealth;
        StartCoroutine(UpdateWaterLevel());
    }

    public void Damage(DamageValue damage)
    {
        BottomHealth -= damage.bottom;
        DeckHealth -= damage.deck;
        SailHealth -= damage.sails;
        ClampHealth();
        OnHealthChange.Invoke();
        if (BottomHealth == 0 && DeckHealth == 0)
        {
            Sink();
        }
    }

    public void Repair(RepairValue repair)
    {
        BottomHealth += repair.bottom;
        DeckHealth += repair.deck;
        SailHealth += repair.sails;
        ClampHealth();
        OnHealthChange.Invoke();
    }
    public void RepairAll()
    {
        RepairValue repair = new RepairValue (maxBottomHealth-BottomHealth, maxDeckHealth-DeckHealth, maxSailHealth-SailHealth);
        Repair(repair);
    }
    public void AddToMaxHealth(int additionalHealth)
    {
        maxBottomHealth += additionalHealth;
        maxDeckHealth += additionalHealth;
        maxSailHealth += additionalHealth;
    }

    void ClampHealth()
    {
        BottomHealth = Mathf.Clamp(BottomHealth, 0, maxBottomHealth);
        DeckHealth = Mathf.Clamp(DeckHealth, 0, maxDeckHealth);
        SailHealth = Mathf.Clamp(SailHealth, 0, maxSailHealth);
    }

    IEnumerator UpdateWaterLevel()
    {
        while (!HasSunk)
        {
            yield return new WaitForSeconds(1f);
            // if bottom has taken damage
            if (maxBottomHealth - BottomHealth != 0)
            {
                WaterLevel += (maxBottomHealth - BottomHealth) * waterIncreaseRate;
            }
            // if bottom is repaired/at max health
            else if (WaterLevel > 0)
            {
                WaterLevel -= waterDecreaseRate;
                WaterLevel = Mathf.Clamp(WaterLevel, 0, MaxWaterLevel);
            }
            OnWaterLevelChange.Invoke();
            if (WaterLevel >= MaxWaterLevel)
            {
                Sink();
            }
        }
    }

    void Sink()
    {
        if (!HasSunk)
        {
            print(gameObject.name + " has sunk!");
            OnShipSink?.Invoke();
            HasSunk = true;
        }
    }
}
