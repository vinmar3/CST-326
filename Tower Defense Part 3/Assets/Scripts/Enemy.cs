using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public Path route1;
    public Path route2;
    private Waypoint[] myPathThroughLife;
    public int coinWorth;
    public float health;
    public float startHealth;
    public float speed = .25f;
    private int index = 0;
    private Vector3 nextWaypoint;
    private bool stop = false;
    public Image healthBar;
    public UnityEvent DeathEvent;
    public ParticleSystem particle;

    void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        particle.Stop();
    }
    void Start()
    {
        health = startHealth;
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

    public void EnemyHealth(float hitAmount)
    {
        health -= hitAmount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            if (gameObject.name == "BigBadGuy(Clone)")
            {
                GameObject.Find("Player").GetComponent<Player>().coins += coinWorth;
                Debug.Log($"The player now has {GameObject.Find("Player").GetComponent<Player>().coins} coins");
                DeathEvent.Invoke();
                DeathEvent.RemoveAllListeners();
                GetComponent<MeshRenderer>().enabled = false;
                particle.Play();
                Destroy(this.gameObject, 0.5f);
            }
            else if (gameObject.name == "SmallBadGuy(Clone)")
            {
                GameObject.Find("Player").GetComponent<Player>().coins += coinWorth;
                Debug.Log($"The player now has {GameObject.Find("Player").GetComponent<Player>().coins} coins");
                DeathEvent.Invoke();
                DeathEvent.RemoveAllListeners();
                GetComponent<MeshRenderer>().enabled = false;
                particle.Play();
                Destroy(this.gameObject, 0.5f);
            }
        }
    }
}
