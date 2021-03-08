using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform allEnemies;
    public float speed = 0.5f;

    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.1f, 0.5f);
        allEnemies = GetComponent<Transform>();
    }

    void MoveEnemy()
    {
        allEnemies.position += Vector3.right * speed;

        foreach (Transform enemy in allEnemies)
        {
            if (enemy.position.x < -8 || enemy.position.x > 8)
            {
                speed = -speed;
                allEnemies.position += Vector3.down * 0.5f;
                return;
            }
        }
    }
}
