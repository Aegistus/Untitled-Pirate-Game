using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour, ICannon
{

    public GameObject projectile;
    public Transform muzzleTransform;
    public float maxReloadTime = 3f;//set tempRT to same value
    float currentReloadTime = 0f;
    public float bulletSpeed = 50f;
    public float amountOfCannonBalls = 1f;

    // Update is called once per frame
    void Update()
    {
        if(amountOfCannonBalls <= 0)
        {
            Reload();
        }
    }
    public void Reload()
    {
        currentReloadTime -= Time.deltaTime;
        if(currentReloadTime <= 0)
        {
            //play reload sound
            amountOfCannonBalls = 1f;
        }
    }

    public void Shoot()
    {
        if (amountOfCannonBalls <= 0)
        {
            return;
        }
        amountOfCannonBalls--;
        currentReloadTime = maxReloadTime;
        GameObject currentBullet = Instantiate(projectile, muzzleTransform.position, muzzleTransform.rotation);
        Rigidbody rig = currentBullet.GetComponent<Rigidbody>();

        rig.AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);
    }
}
