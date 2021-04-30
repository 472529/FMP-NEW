using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public Gun gun;
    public GameObject gunContainer;

    private void Update()
    {
        gunContainer = GameObject.FindGameObjectWithTag("GunContainer");
        gun = gunContainer.GetComponentInChildren<Gun>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            gun.allAmmo += 10;
            Destroy(gameObject);
        }
    }

}
