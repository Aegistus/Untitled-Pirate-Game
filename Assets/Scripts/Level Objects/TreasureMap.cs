using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TreasureMap : MonoBehaviour
{
    public event Action OnMapFound;

    [SerializeField] int playerLayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            OnMapFound?.Invoke();
            Destroy(gameObject);
        }
    }
}
