using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpack : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            player.currentHealth += 20;
            Destroy(gameObject);
        }
    }
}
