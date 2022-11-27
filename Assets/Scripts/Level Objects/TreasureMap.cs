using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TreasureMap : MonoBehaviour
{
    public event Action OnMapFound;

    [SerializeField] int playerLayer;

    int collectSoundID;

    void Start()
    {
        collectSoundID = SoundManager.Instance.GetSoundID("Map_Collect");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            OnMapFound?.Invoke();
            SoundManager.Instance.PlaySoundGlobal(collectSoundID);
            Destroy(gameObject);
        }
    }
}
