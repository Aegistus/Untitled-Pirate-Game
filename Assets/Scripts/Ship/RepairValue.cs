using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RepairValue
{
    public int bottom;
    public int deck;
    public int sails;

    public RepairValue(int bottom, int deck, int sails)
    {
        this.bottom = bottom;
        this.deck = deck;
        this.sails = sails;
    }

    public static explicit operator RepairValue(float v)
    {
        throw new NotImplementedException();
    }
}
