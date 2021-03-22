using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Path route1;
    public Path route2;
    private Waypoint[] myPathThroughLife;
    public int coinWorth;
    public float health;
    public float speed = .25f;
    private int index = 0;
    private Vector3 nextWaypoint;
    private bool stop = false;

    void Awake()
    {
        if(Random.Range(1, 100) > 50)
        {
            myPathThroughLife = route1.path;
        }
        else
        {
            myPathThroughLife = route2.path;
        }
        transform.position = myPathThroughLife[index].transform.position;
        Recalculate();
    }

    void Update()
    {
        if (!stop)
        {
          if ((transform.position - myPathThroughLife[index + 1].transform.position).magnitude < .1f)
          {
            index = index + 1;
            Recalculate();
          }


          Vector3 moveThisFrame = nextWaypoint * Time.deltaTime * speed;
          transform.Translate(moveThisFrame);
        }
    }

    void Recalculate()
    {
        if (index < myPathThroughLife.Length -1)
        {
          nextWaypoint = (myPathThroughLife[index + 1].transform.position - myPathThroughLife[index].transform.position).normalized;

        }
        else
        {
          stop = true;
        }
    }

    public void EnemyHealth()
    {
        health -= 1;
        if (health > 0)
        {
            Debug.Log($"{gameObject.name} now has {health} hp left");
        }
        else if (health <= 0)
        {
            Debug.Log($"{gameObject.name} is dead");
            if (gameObject.name == "BigBadGuy")
            {
                GameObject.Find("Player").GetComponent<Player>().coins += coinWorth;
                Debug.Log($"The player now has {GameObject.Find("Player").GetComponent<Player>().coins} coins");
            }
            else if (gameObject.name == "SmallBadGuy")
            {
                GameObject.Find("Player").GetComponent<Player>().coins += coinWorth;
                Debug.Log($"The player now has {GameObject.Find("Player").GetComponent<Player>().coins} coins");
            }
            Destroy(gameObject);
        }
    }
}
