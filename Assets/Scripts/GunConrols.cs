using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunConrols : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;

    public Camera fpsCam;
    public ParticleSystem gunSmoke;
    public GameObject boom;

    private float nextTimeToFire = 0f;


    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentAmmo <= 0)
        {
            Reload();
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Reload()
    {
        Debug.Log("Reloading.......");
        currentAmmo = maxAmmo;
    }

    void Shoot()
    {
        gunSmoke.Play();

        currentAmmo--;

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyControls enemy = hit.transform.GetComponent<EnemyControls>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject thisboom = Instantiate(boom, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(thisboom, 2f);
        }
    }
}
