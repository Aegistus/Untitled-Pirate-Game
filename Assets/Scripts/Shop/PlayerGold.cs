using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGold : MonoBehaviour
{
    public UnityEvent<int> OnGoldChange;

    public int goldAmount = 5;

    void Start()
    {
        OnGoldChange.Invoke(goldAmount);
    }

    public bool TrySpendGold(int g)
    {
        if (goldAmount >= g)
        {
            goldAmount -= g;
            OnGoldChange.Invoke(goldAmount);
            return true;
        }
        OnGoldChange.Invoke(goldAmount);
        return false;
    }

    public void AddGold(int g)
    {
        goldAmount += g;
        OnGoldChange.Invoke(goldAmount);
    }
}
