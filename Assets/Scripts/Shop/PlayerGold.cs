using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGold : MonoBehaviour
{
    private int goldAmount;
    [SerializeField] int startingGold = 0;
    [SerializeField] TMP_Text goldText;

    void Start()
    {
        goldAmount = startingGold;
        goldText.text = goldAmount.ToString();
    }
    
    public bool TrySpendGold(int g)
    {
        if (goldAmount >= g)
        {
            goldAmount -= g;
            goldText.text = goldAmount.ToString();
            return true;
        }
        return false;
    }

    public void AddGold(int g)
    {
        goldAmount += g;
        goldText.text = goldAmount.ToString();
    }
}