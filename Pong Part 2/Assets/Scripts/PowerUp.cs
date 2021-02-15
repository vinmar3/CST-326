using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool Powerup1;

    void OnTriggerEnter(Collider collider)
    {
        if (Powerup1)
        {
            if (collider.CompareTag("Ball"))
            {
                InvisibleBall();
            }
        }
        else
        {
            if (collider.CompareTag("Ball"))
            {
                SendRandom();
            }
        }
    }

    void InvisibleBall()
    {
        GameObject.Find("Ball").GetComponent<Renderer>().enabled = false;
        gameObject.SetActive(false);
    }

    void SendRandom()
    {
        GameObject.Find("Ball").GetComponent<Ball>().BallRandom();
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        gameObject.SetActive(true);
    }
}
