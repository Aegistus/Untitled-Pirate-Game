using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour, ICannon
{
    [SerializeField] string projectileName = "Cannonball";
    [SerializeField] Transform muzzleTransform;
    [SerializeField] float reloadTime = 3f;

    int projectileID;
    bool isLoaded = true;
    PoolManager pool;
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

    public void Shoot()
    {
        if (!isLoaded)
        {
            return;
        }
        pool.SpawnObjectWithLifetime(projectileID, muzzleTransform.position, muzzleTransform.rotation, 10f);
        sound.PlaySoundAtPosition(fireSoundID, transform.position);
        isLoaded = false;
        Reload();
    }
}
