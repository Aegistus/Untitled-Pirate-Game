using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGold : MonoBehaviour
{
    public int goldAmount = 5;

    void Start()
    {
    }

    public bool TrySpendGold(int g)
    {
        if (goldAmount >= g)
        {
            goldAmount -= g;
            return true;
        }
        return false;
    }

    public void AddGold(int g)
    {
        goldAmount += g;
    }
}
