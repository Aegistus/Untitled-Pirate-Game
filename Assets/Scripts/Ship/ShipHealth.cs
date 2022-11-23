using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipHealth : MonoBehaviour
{
    public UnityEvent OnHealthChange;
    public UnityEvent OnWaterLevelChange;
    public static readonly float waterIncreaseRate = .02f;

    [SerializeField] int maxBottomHealth = 1000;
    [SerializeField] int maxDeckHealth = 1000;
    [SerializeField] int maxSailHealth = 1000;

    public int BottomHealth { get; private set; }
    public int DeckHealth { get; private set; }
    public int SailHealth { get; private set; }

    public float WaterLevel { get; private set; } = 0f;
    public float MaxWaterLevel { get; private set; } = 1000f;
 
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
        BottomHealth = Mathf.Clamp(BottomHealth, 0, maxBottomHealth);
        DeckHealth = Mathf.Clamp(DeckHealth, 0, maxDeckHealth);
        SailHealth = Mathf.Clamp(SailHealth, 0, maxSailHealth);
    }

    IEnumerator UpdateWaterLevel()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            WaterLevel += (maxBottomHealth - BottomHealth) * waterIncreaseRate;
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
