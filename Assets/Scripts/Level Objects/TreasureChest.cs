using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TreasureChest : MonoBehaviour
{
    public bool Discovered { get; private set; }

    public UnityEvent<TreasureChest> OnChestDiscovered;

    
}
