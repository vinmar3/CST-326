﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    public float speed = 5;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        Fire();
    }

    private void Fire()
    {
        myRigidbody2D.velocity = Vector2.up * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Barrier")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
