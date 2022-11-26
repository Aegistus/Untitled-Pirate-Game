using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    public DamageValue damage;

    Rigidbody rig;
    PoolManager pool;
    SoundManager sound;
    int waterImpactID;
    int waterSoundID;
    int shipImpactID;
    int shipSoundID;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Start()
    {
        pool = PoolManager.Instance;
        sound = SoundManager.Instance;
        waterImpactID = pool.GetPoolObjectID("Impact_Water");
        waterSoundID = sound.GetSoundID("Cannonball_Impact_Water");
        shipImpactID = pool.GetPoolObjectID("Impact_Ship");
        shipSoundID = sound.GetSoundID("Cannonball_Impact_Ship");
    }

    public void SetDamageModifier(float damageMod)
    {
        damage.bottom = (int)(damage.bottom * damageMod);
        damage.deck = (int)(damage.deck * damageMod);
        damage.sails = (int)(damage.sails * damageMod);
    }

    void OnEnable()
    {
        rig.AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision collision)
    {
        ShipHealth s = collision.gameObject.GetComponentInParent<ShipHealth>();
        if (s != null)
        {
            s.Damage(damage);
            pool.SpawnObjectWithLifetime(shipImpactID, transform.position, transform.rotation, 5f);
            sound.PlaySoundAtPosition(shipSoundID, transform.position);
        }
        else
        {
            pool.SpawnObjectWithLifetime(waterImpactID, transform.position, transform.rotation, 5f);
            sound.PlaySoundAtPosition(waterSoundID, transform.position);
        }
        rig.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
