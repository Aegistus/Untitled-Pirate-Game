using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class WorldBoundary : MonoBehaviour
{
    [SerializeField] float boundaryRadius;
    [SerializeField] DamageValue stormDamage;
    [SerializeField] AudioSource audioSource;

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
            Debug.Log("First: " + inStorm);
            if (!inStorm)
            {
                Debug.Log("In storm");
                inStorm = true;
                StartCoroutine(DamagePlayer());
                stormVolume.enabled = true;
                SoundManager.FadeInCaller(audioSource, 0.01f, .5f);
            }
        }
        else
        {
            Debug.Log("Second: " + inStorm);
            if (inStorm)
            {
                Debug.Log("No longer in storm");
                inStorm = false;
                StopCoroutine(DamagePlayer());
                stormVolume.enabled = false;
                SoundManager.FadeOutCaller(audioSource, 0.01f);

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
        while (inStorm)
        {
            yield return new WaitForSeconds(1);
            playerHealth.Damage(stormDamage);
        }
    }
}
