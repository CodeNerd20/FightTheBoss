using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunConrols : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;

    public Camera fpsCam;
    public ParticleSystem gunSmoke;
    public GameObject boom;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        gunSmoke.Play();

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
