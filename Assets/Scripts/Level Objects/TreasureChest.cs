using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TreasureChest : MonoBehaviour
{
    [SerializeField] int goldReward;
    [SerializeField] int playerLayer;

    int collectSoundID;

    void Start()
    {
        collectSoundID = SoundManager.Instance.GetSoundID("Chest_Collect");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            SoundManager.Instance.PlaySoundGlobal(collectSoundID);
            FindObjectOfType<PlayerGold>().AddGold(goldReward);
            Destroy(gameObject);
        }
    }
}
