using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    public Image baseHealthBar;
    public float baseHP = 100;
    public float healthLeft;

    private void Start()
    {
        healthLeft = baseHP;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "SmallBadGuy(Clone)")
        {
            healthLeft -= 5;
            baseHealthBar.fillAmount = healthLeft / baseHP;
            Destroy(collision.gameObject);
            GameOver();
        }
        else if (collision.gameObject.name == "BigBadGuy(Clone)")
        {
            healthLeft -= 10;
            baseHealthBar.fillAmount = healthLeft / baseHP;
            Destroy(collision.gameObject);
            GameOver();
        }
    }

    public void GameOver()
    {
        if(baseHealthBar.fillAmount <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
