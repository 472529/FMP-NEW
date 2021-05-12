using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 50f;
    public Rigidbody rb;
    public EnemyAiTutorial enemy;
    AudioSource jet;
    public ParticleSystem fireBlast;
    public ParticleSystem explosion;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemy = GetComponent<Enemy>();
        jet = GetComponent<AudioSource>();
        fireBlast = GameObject.FindGameObjectWithTag("EnemyFire").GetComponent<ParticleSystem>();
        explosion = GameObject.FindGameObjectWithTag("Explosion").GetComponent<ParticleSystem>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        rb.constraints = RigidbodyConstraints.None;
        enemy.enabled = false;
        jet.enabled = false;
        fireBlast.Pause();
        explosion.Play();
        Destroy(gameObject, 5f);
        

    }
}
