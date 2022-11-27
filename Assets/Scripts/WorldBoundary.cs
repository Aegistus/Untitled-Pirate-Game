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
            if (!inStorm)
            {
                inStorm = true;
                StartCoroutine(DamagePlayer());
                stormVolume.enabled = true;
            }
        }
        else
        {
            if (inStorm)
            {
                inStorm = false;
                StopCoroutine(DamagePlayer());
                stormVolume.enabled = false;
            }
        }
    }

    public Vector3 GetRandomPointInBounds()
    {
        Vector3 point = Random.insideUnitSphere * boundaryRadius;
        point.y = 0;
        return point;
    }

    IEnumerator DamagePlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            playerHealth.Damage(stormDamage);
        }
    }
}
