using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyChecker : MonoBehaviour
{
    public GameObject[] enemies;

    public void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
