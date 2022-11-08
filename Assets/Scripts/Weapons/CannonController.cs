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

    void Start()
    {
        pool = PoolManager.Instance;
        projectileID = pool.GetPoolObjectID(projectileName);
    }

    public void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    public IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(reloadTime);
        isLoaded = true;
    }

    public void Shoot()
    {
        if (!isLoaded)
        {
            return;
        }
        pool.SpawnObjectWithLifetime(projectileID, muzzleTransform.position, muzzleTransform.rotation, 10f);
    }
}
