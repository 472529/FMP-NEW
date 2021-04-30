using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage = 50;

    private Transform player;
    private Vector3 target;
    public Player health;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            health.currentHealth -= damage;
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            health.currentHealth -= damage;
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
