using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3;
    public GameObject EnemyBullet;
    public Transform shottingOffset;
    public float shootTime = 5f;
    private Animator enemyAnimator;
    public GameObject shot;
    private AudioSource audioSource;
    public AudioClip enemyBoom;
    public AudioClip enemyShoot;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        enemyAnimator = GetComponent<Animator>();
        shootTime = shootTime + Random.Range(1f, 10f);
    }

    void Update()
    {
        if (Time.time > shootTime && shot == null)
        {
            enemyAnimator.SetTrigger("Shoot");
            audioSource.PlayOneShot(enemyShoot);
            shootTime = shootTime + Random.Range(1f, 10f);
            shot = Instantiate(EnemyBullet, shottingOffset.position, Quaternion.identity);
            Destroy(shot, 5f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            enemyAnimator.SetTrigger("Boom");
            audioSource.PlayOneShot(enemyBoom);
            Destroy(collision.gameObject);
            Destroy(gameObject, 1f);
            if (gameObject.tag == "Enemy")
            {
                GameObject.Find("UI").GetComponent<UI>().Enemy1Points();
            }
            else if (gameObject.tag == "Enemy2")
            {
                GameObject.Find("UI").GetComponent<UI>().Enemy2Points();
            }
            else if (gameObject.tag == "Enemy3")
            {
                GameObject.Find("UI").GetComponent<UI>().Enemy3Points();
            }
            else if (gameObject.tag == "Enemy4")
            {
                GameObject.Find("UI").GetComponent<UI>().Enemy4Points();
            }
        }
    }
}
