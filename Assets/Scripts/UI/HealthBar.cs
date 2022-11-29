using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image green;         //health
    public Image blue;          //water level
    public Image red;           //sails
    public ShipHealth status;

    void Update()
    {
        green.fillAmount = ((float)status.BottomHealth / (float)status.maxBottomHealth + (float)status.DeckHealth / (float)status.maxDeckHealth) / 2.0f;
        blue.fillAmount = (float)status.WaterLevel / (float)status.MaxWaterLevel;
        red.fillAmount = 1.0f - (float)status.SailHealth / (float)status.maxSailHealth;
    }
}