using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour, ICannon
{
    [SerializeField] string projectileName = "Cannonball";
    [SerializeField] Transform muzzleTransform;
    [SerializeField] ParticleSystem smokeEffect;
    [SerializeField] float baseReloadTime = 3f;

    public bool IsLoaded { get; private set; } = true;
    float reloadTimeActual;

    int projectileID;
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

    public void Reload(float delayModifier)
    {
        reloadTimeActual = baseReloadTime * delayModifier;
        IsLoaded = false;
        StartCoroutine(ReloadCoroutine());
    }

    public IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(reloadTimeActual);
        sound.PlaySoundAtPosition(reloadSoundID, transform.position);
        IsLoaded = true;
    }

    public void Shoot(float damageModifier)
    {
        if (!IsLoaded)
        {
            return;
        }
        GameObject projectileGO = pool.SpawnObjectWithLifetime(projectileID, muzzleTransform.position, muzzleTransform.rotation, 10f);
        ProjectileController projectile = projectileGO.GetComponent<ProjectileController>();
        projectile.SetDamageModifier(damageModifier);
        sound.PlaySoundAtPosition(fireSoundID, transform.position);
        smokeEffect.Play();
        IsLoaded = false;
    }
}
