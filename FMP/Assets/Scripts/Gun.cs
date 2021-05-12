using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 2f;

    public int maxAmmo;
    public int allAmmo;
    public int currentAmmo;
    public float reloadTime = 2f;
    private bool isReloading = false;
    public bool isEquipped = false;
    public Animator anim;

    PlayerController player;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public New_Weapon_Recoil_Script recoil;
    public AudioSource gunSound;

    private float nextTimeForFire = 2f;

    private void Awake()
    {
        gunSound = GetComponent<AudioSource>();
        recoil = GetComponent<New_Weapon_Recoil_Script>();
        fpsCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        impactEffect = GameObject.FindGameObjectWithTag("DefaultHit");
        gunSound = GetComponent<AudioSource>();

        currentAmmo = maxAmmo;

    }
    void Update()
    {
        
        if (isReloading)
        {
            return;
        }
        if (allAmmo <= 0)
        {

        }

        else if (currentAmmo == 0)
        {
            StartCoroutine(Reload());
            return;
        }

        
        /*else if (Input.GetKey(KeyCode.R) && !isReloading)
        {
            StartCoroutine(Reload());
        }*/

        else if (Input.GetButton("Fire1") && Time.time >= nextTimeForFire && allAmmo >= 0)
        {
            nextTimeForFire = Time.time + 1f / fireRate;
            muzzleFlash.Play();
            Shoot();
        }

        


    }

    void Shoot()
    {
        isReloading = false;
        isEquipped = true;
        gunSound.Play();
        recoil.Fire();
        
        RaycastHit hit;

        currentAmmo--;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

        }  
    }



    IEnumerator Reload()
    {
        isReloading = true;
        isEquipped = true;
        Debug.Log("Reloading...");

        anim.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);
        anim.SetBool("Reloading", false);
        yield return new WaitForSeconds(reloadTime - .25f);

        if (allAmmo > 0)
        {
            currentAmmo += maxAmmo;
            allAmmo -= maxAmmo;
        }
        else
        {
           
        }

        isReloading = false;
    }
}
