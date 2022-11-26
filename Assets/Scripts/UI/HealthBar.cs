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
        green.fillAmount = status.BottomHealth / status.maxBottomHealth;
        //Debug.Log(status.BottomHealth / status.maxBottomHealth);
        blue.fillAmount = status.WaterLevel / status.MaxWaterLevel;
        //Debug.Log(status.WaterLevel / status.MaxWaterLevel);
        red.fillAmount = status.SailHealth / status.maxSailHealth;
        //Debug.Log(status.SailHealth / status.maxSailHealth);
    }
}