using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBoundary : MonoBehaviour
{
    [SerializeField] float boundaryRadius;
    [SerializeField] DamageValue stormDamage;

    float boundaryRadiusSquared;
    Transform player;
    ShipHealth playerHealth;

    void Awake()
    {
        boundaryRadiusSquared = Mathf.Pow(boundaryRadius, 2);
    }

    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        playerHealth = player.GetComponent<ShipHealth>();
    }

    void Update()
    {
        if ((transform.position - player.position).sqrMagnitude > boundaryRadiusSquared)
        {
            print("Player out of bounds");
        }
    }
}
