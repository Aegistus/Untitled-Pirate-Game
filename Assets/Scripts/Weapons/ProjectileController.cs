using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    public DamageValue damage;

    Rigidbody rig;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rig.AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ShipHealth s = collision.gameObject.GetComponent<ShipHealth>();
        if (s != null)
        {
            s.Damage(damage);
        }
        rig.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
