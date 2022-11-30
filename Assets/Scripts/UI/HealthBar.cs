using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image green;         //health
    public Image blue;          //water level
    public Image red;           //sails
    ShipHealth health;

    void Start()
    {
        if (health == null)
        {
            health = FindObjectOfType<PlayerController>().GetComponent<ShipHealth>();
        }
        UpdateHealthbar();
        health.OnHealthChange.AddListener(UpdateHealthbar);
    }

    void UpdateHealthbar()
    {
        green.fillAmount = ((float)health.BottomHealth / (float)health.maxBottomHealth + (float)health.DeckHealth / (float)health.maxDeckHealth) / 2.0f;
        blue.fillAmount = (float)health.WaterLevel / (float)health.MaxWaterLevel;
        red.fillAmount = 1.0f - (float)health.SailHealth / (float)health.maxSailHealth;
    }
}