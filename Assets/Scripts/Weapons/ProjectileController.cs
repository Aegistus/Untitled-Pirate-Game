using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    public DamageValue damage;
    private void OnEnable()
    {
        Rigidbody rig = this.GetComponent<Rigidbody>();
        rig.AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        ShipHealth s = collision.gameObject.GetComponent<ShipHealth>();
        s.Damage(damage);

        this.gameObject.SetActive(false);
    }
}
