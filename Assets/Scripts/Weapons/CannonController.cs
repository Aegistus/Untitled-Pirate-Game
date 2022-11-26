using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour, ICannon
{
    [SerializeField] string projectileName = "Cannonball";
    [SerializeField] Transform muzzleTransform;
    [SerializeField] ParticleSystem smokeEffect;
    [SerializeField] float reloadTime = 3f;

    int projectileID;
    bool isLoaded = true;
    PoolManager pool;

    // sound
    SoundManager sound;
    string fireSoundString = "Cannon_Shot";
    string reloadSoundString = "Cannon_Reload";
    int fireSoundID;
    int reloadSoundID;

    void Start()
    {
        pool = PoolManager.Instance;
        projectileID = pool.GetPoolObjectID(projectileName);
        sound = SoundManager.Instance;
        fireSoundID = sound.GetSoundID(fireSoundString);
        reloadSoundID = sound.GetSoundID(reloadSoundString);
    }

    public void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    public IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(reloadTime);
        sound.PlaySoundAtPosition(reloadSoundID, transform.position);
        isLoaded = true;
    }

    public void Shoot(float damageModifier)
    {
        if (!isLoaded)
        {
            return;
        }
        GameObject projectileGO = pool.SpawnObjectWithLifetime(projectileID, muzzleTransform.position, muzzleTransform.rotation, 10f);
        ProjectileController projectile = projectileGO.GetComponent<ProjectileController>();
        projectile.SetDamageModifier(damageModifier);
        sound.PlaySoundAtPosition(fireSoundID, transform.position);
        smokeEffect.Play();
        isLoaded = false;
        Reload();
    }

    public void decreaseReloadTime(float time)
    {
        reloadTime -= time;
    }
}
