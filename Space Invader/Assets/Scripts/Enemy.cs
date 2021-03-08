using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3;
    public GameObject EnemyBullet;
    public Transform shottingOffset;
    public float shootTime = 1f;

    // Update is called once per frame
    void Start()
    {
        shootTime = shootTime + Random.Range(1f, 7f);
    }

    void Update()
    {
        if (Time.time > shootTime)
        {
            shootTime = shootTime + Random.Range(1f, 7f);
            Instantiate(EnemyBullet, shottingOffset.position, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            if(gameObject.name == "Enemy")
            {
                GameObject.Find("UI").GetComponent<UI>().Enemy1Points();
            }
            else if(gameObject.name == "Enemy2")
            {
                GameObject.Find("UI").GetComponent<UI>().Enemy2Points();
            }
            else if (gameObject.name == "Enemy3")
            {
                GameObject.Find("UI").GetComponent<UI>().Enemy3Points();
            }
            else if (gameObject.name == "Enemy4")
            {
                GameObject.Find("UI").GetComponent<UI>().Enemy4Points();
            }
        }
    }
}
