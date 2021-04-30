using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public Object ShotGun;
    public Object AK47;
    public Object Sniper;
    
    void Start()
    {
        ShotGun = Resources.Load("870_Shotgun 1");
        AK47 = Resources.Load("AK-47 1");
        Sniper = Resources.Load("Sniper");
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
            Instantiate(AK47, transform.position, transform.rotation);
        }
        else if(random == 2)
        {
            Instantiate(Sniper, transform.position, transform.rotation);
        }
    }

   
    

    
}
