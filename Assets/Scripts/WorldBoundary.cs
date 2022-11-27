using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class WorldBoundary : MonoBehaviour
{
    [SerializeField] float boundaryRadius;
    [SerializeField] DamageValue stormDamage;

    float boundaryRadiusSquared;
    Transform player;
    ShipHealth playerHealth;
    PostProcessVolume stormVolume;
    bool inStorm = false;

    void Awake()
    {
        boundaryRadiusSquared = Mathf.Pow(boundaryRadius, 2);
        stormVolume = GetComponent<PostProcessVolume>();
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
            playerHealth.Damage(stormDamage);
            inStorm = true;
        }
        else
        {
            inStorm = false;    
        }
        if (inStorm && !stormVolume.enabled)
        {
            stormVolume.enabled = true;
        }
        if (!inStorm && stormVolume.enabled)
        {
            stormVolume.enabled = false;
        }
    }

    public Vector3 GetRandomPointInBounds()
    {
        Vector3 point = Random.insideUnitSphere * boundaryRadius;
        point.y = 0;
        return point;
    }
}
