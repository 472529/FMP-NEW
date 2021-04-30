using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    public GameObject player;
    public Gun gun;
    public TMP_Text text;
    public PickupController PUC;

    

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text = GameObject.FindGameObjectWithTag("UI").GetComponent<TMP_Text>();
        gun = GameObject.FindGameObjectWithTag("GunContainer").GetComponentInChildren<Gun>();
        
        if(gun == null)
        {
           
        }
        else
        {
            PickupChecker();
        }
    }

    public void PickupChecker()
    {
        text.text = "Ammo " + gun.currentAmmo + " / " + (gun.allAmmo - gun.maxAmmo);
    }
}
