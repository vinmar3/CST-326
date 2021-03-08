using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    public float speed = 2;
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        Fire();
    }

    private void Fire()
    {
        myRigidbody2D.velocity = Vector2.down * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Barrier" || collision.gameObject.name == "Player" || collision.gameObject.name == "Bullet(Clone)")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
