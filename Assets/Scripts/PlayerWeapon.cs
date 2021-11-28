using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    public float damage = 40;
    public float range = 100;
    public float fireRate = 15f;
    public float impactForce=60f;

    [Header("Assault Rifle")]
    public int bulletPerClip = 24;
    public int currentAmmo;
    public float fireDelay=0.3f;
    public float reloadTime = 2.5f;
    private bool isReloading = false;
    private bool isFireDelay = false;

    public Camera[] fpsCam;
    public ParticleSystem effectFire;
    public GameObject impactEffect;
    public bool tembak;

    private float nextTimeToFire = 0;

    private void Start()
    {
       currentAmmo = bulletPerClip;

    }
    private void Update()
    {
        if (isReloading)
            return;

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (tembak && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        FindObjectOfType<managerCharacter>().startReload();
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        FindObjectOfType<managerCharacter>().endReload();
        currentAmmo = bulletPerClip;
        isReloading = false;
    }
    void Shoot()
    {
        StartCoroutine(firedelay());
        
    }

    IEnumerator firedelay()
    {
        isFireDelay = false;
        yield return new WaitForSeconds(fireDelay);
        currentAmmo--;
        effectFire.Play();
        RaycastHit hit;
        foreach (Camera i in fpsCam)
        {
            if (Physics.Raycast(i.transform.position, i.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                targetEnemy target = hit.transform.GetComponent<targetEnemy>();
                if (target != null)
                {
                    target.takeDamage(damage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
        }
        isFireDelay = true;
    }
}
