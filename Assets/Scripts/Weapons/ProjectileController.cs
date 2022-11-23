using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    public DamageValue damage;

    Rigidbody rig;
    PoolManager pool;
    int waterImpactID;
    int shipImpactID;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Start()
    {
        pool = PoolManager.Instance;
        waterImpactID = pool.GetPoolObjectID("Impact_Water");
        shipImpactID = pool.GetPoolObjectID("Impact_Ship");
    }

    private void OnEnable()
    {
        rig.AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ShipHealth s = collision.gameObject.GetComponentInParent<ShipHealth>();
        if (s != null)
        {
            s.Damage(damage);
            pool.SpawnObjectWithLifetime(shipImpactID, transform.position, transform.rotation, 5f);
        }
        else
        {
            pool.SpawnObjectWithLifetime(waterImpactID, transform.position, transform.rotation, 5f);
        }
        rig.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
