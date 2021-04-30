using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    Object enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = Resources.Load("MachineGunRobot");
        Spanwer();
    }

    // Update is called once per frame
    void Spanwer()
    {
       float rand = Random.Range(-1, 2);

       if(rand == 1)
        {
            Instantiate(enemy, transform.position, transform.rotation);
        }

    }
}
