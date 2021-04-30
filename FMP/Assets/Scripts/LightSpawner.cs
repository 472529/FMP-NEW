using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawner : MonoBehaviour
{
    Object light;

    private void Start()
    {
        light = Resources.Load("Lamp");
        Spawner();
    }

    void Spawner()
    {
        float rand = Random.Range(0, 4);
        if (rand == 0)
        {
            Debug.Log("0");
            Instantiate(light, transform.position, transform.rotation);
        }
        else
        {
        
        }
    }
}
