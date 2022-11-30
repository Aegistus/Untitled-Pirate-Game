using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    public TMP_Text goldText;

    PlayerGold playerGold;

    void Start()
    {
        playerGold = FindObjectOfType<PlayerGold>();
        UpdateGold(playerGold.goldAmount);
        playerGold.OnGoldChange.AddListener(UpdateGold);
    }

    void UpdateGold(int gold)
    {
        goldText.text = gold.ToString();
    }
}
