using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    public TMP_Text goldText;
    public PlayerGold current;

    void Start()
    {
        goldText.text = current.goldAmount.ToString();
    }

    void Update()
    {
        goldText.text = current.goldAmount.ToString();
    }
}