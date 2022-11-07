using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour, ICannon
{

    public GameObject projectile;
    public Transform muzzleTransform;
    public float reloadTime = 7f;
    public float bulletSpeed = 5f;
    private float shootDelay = 1f;
    public float amountOfCannonBalls = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }//code I found and used for previous project to move with the mouse

        shootDelay -= Time.deltaTime;
        if (Input.GetButton("Fire1") && shootDelay < 0 && amountOfCannonBalls > 0)
        {
            Shoot();
            shootDelay = 1f;
            amountOfCannonBalls--;
        }

        if(amountOfCannonBalls == 0)
        {
            reloadTime -= Time.deltaTime;
            Reload(reloadTime);
        }
    }
    public void Reload(float time)
    {
        if(time < 0)
        {
            //play reload sound
            amountOfCannonBalls = 5f;
            reloadTime = 7f;
        }
    }

    public void Shoot()
    {
        GameObject currentBullet = Instantiate(projectile, muzzleTransform.position, muzzleTransform.rotation);
        Rigidbody rig = currentBullet.GetComponent<Rigidbody>();

        rig.AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);
    }
}
