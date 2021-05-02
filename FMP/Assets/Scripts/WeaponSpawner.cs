using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public Object ShotGun;
    public Object Rifle;
    public Object Sniper;
    
    void Start()
    {
        ShotGun = Resources.Load("Heavy");
        Rifle = Resources.Load("Rifle");
        Sniper = Resources.Load("Sniper 1");
        Spawner();
    }

    public void Spawner()
    {
        float random = Random.Range(1, 6);
        if(random == 1)
        {
            Instantiate(ShotGun, transform.position, transform.rotation);

        }
        else if(random == 3)
        {
            Instantiate(Rifle, transform.position, transform.rotation);
        }
        else if(random == 2)
        {
            Instantiate(Sniper, transform.position, transform.rotation);
        }
    }

   
    

    
}
