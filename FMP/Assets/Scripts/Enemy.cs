using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float enemyHealth;
    public float bulletDamg = 10;

    public LayerMask whatIsPlayer;

    public GameObject bullet;
    public Transform player;
    Transform lookingAt;
    public ParticleSystem muzzleFlash;
    
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float attackRange;
    public float sightRange;

    public bool playerInSightRange;
    
    

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        muzzleFlash = GameObject.FindGameObjectWithTag("EnemyMuzzleFlash").GetComponent<ParticleSystem>();

        timeBtwShots = startTimeBtwShots;

        
    }

    // Update is called once per frame
    void Update()
    {
        muzzleFlash.Play();
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSightRange)
        {
            FollowPlayer();
            
            transform.rotation = Quaternion.LookRotation(transform.position - player.position);
            transform.LookAt(2 * transform.position - player.position);
        }

    }

    void FollowPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        if (timeBtwShots < -0)
        {
            muzzleFlash.Play();
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
            

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
