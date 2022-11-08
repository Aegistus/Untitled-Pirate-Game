using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamageValue 
{
    public int bottom;
    public int deck;
    public int sails;

    public DamageValue(int bottom, int deck, int sails)
    {
        this.bottom = bottom;
        this.deck = deck;
        this.sails = sails;
    }
}
