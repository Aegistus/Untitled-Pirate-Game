using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour, ICannon
{

    public GameObject projectile;
    public Transform muzzleTransform;
    public float reloadTime = 3f;//set tempRT to same value
    float tempRT = 3f;
    public float bulletSpeed = 5f;
    public float shootDelay = 1f;
    public float amountOfCannonBalls = 1f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shootDelay -= Time.deltaTime;
        if (Input.GetButton("Fire1") && shootDelay < 0 && amountOfCannonBalls > 0)
        {
            Shoot();
            shootDelay = 1f;
            amountOfCannonBalls--;
        }

        if(amountOfCannonBalls == 0)
        {
            Reload();
        }
    }
    public void Reload()
    {
        reloadTime -= Time.deltaTime;
        if(reloadTime <= 0)
        {
            //play reload sound
            amountOfCannonBalls = 1f;
            reloadTime = tempRT;
        }

    }

    public void Shoot()
    {
        GameObject currentBullet = Instantiate(projectile, muzzleTransform.position, muzzleTransform.rotation);
        Rigidbody rig = currentBullet.GetComponent<Rigidbody>();

        rig.AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);
    }
}
