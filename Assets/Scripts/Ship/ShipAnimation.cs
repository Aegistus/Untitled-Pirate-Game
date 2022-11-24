using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnimation : MonoBehaviour
{
    Animator anim;
    int idleAnimHash = Animator.StringToHash("Idle");
    int[] sinkAnimHashes = { Animator.StringToHash("Sink01"), Animator.StringToHash("Sink02") };

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        anim.Play(idleAnimHash);
        GetComponent<ShipHealth>().OnShipSink.AddListener(SinkAnimation);
    }

    // plays a random sinking animation from the variants
    void SinkAnimation()
    {
        anim.Play(sinkAnimHashes[Random.Range(0, sinkAnimHashes.Length)]);
    }
}
