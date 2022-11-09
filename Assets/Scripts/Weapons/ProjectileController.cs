using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    public DamageValue damage;
    private void OnEnable()
    {
        Rigidbody rig = GetComponent<Rigidbody>();
        rig.AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ShipHealth s = collision.gameObject.GetComponent<ShipHealth>();
        if (s != null)
        {
            s.Damage(damage);
        }

        gameObject.SetActive(false);
    }
}
