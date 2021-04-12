using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeManager : MonoBehaviour
{
    public Wave enemyWave;
    public Path enemyPath1;
    public Path enemyPath2;

    IEnumerator Start()
    {
        StartCoroutine("SpawnSmallEnemies");
        StartCoroutine("SpawnBigEnemies");

        yield break;
    }

    IEnumerator SpawnSmallEnemies()
    {
        for (int i = 0; i < enemyWave.groupOfEnemiesInWave.Length; i++)
        {
            for (int j = 0; j < enemyWave.groupOfEnemiesInWave[i].numberOfSmall; j++)
            {
                Enemy spawnedEnemy = Instantiate(enemyWave.groupOfEnemiesInWave[i].smallBadGuy).GetComponent<Enemy>();
                spawnedEnemy.route1 = enemyPath1;
                yield return new WaitForSeconds(enemyWave.groupOfEnemiesInWave[i].coolDownBetweenSmallEnemies);
            }

            yield return new WaitForSeconds(enemyWave.coolDownBetweenSmallWave);
        }
    }

    IEnumerator SpawnBigEnemies()
    {
        for (int i = 0; i < enemyWave.groupOfEnemiesInWave.Length; i++)
        {
            for (int j = 0; j < enemyWave.groupOfEnemiesInWave[i].numberOfBig; j++)
            {
                Enemy spawnedEnemy = Instantiate(enemyWave.groupOfEnemiesInWave[i].bigBadGuy).GetComponent<Enemy>();
                spawnedEnemy.route1 = enemyPath1;
                yield return new WaitForSeconds(enemyWave.groupOfEnemiesInWave[i].coolDownBetweenBigEnemies);
            }

            yield return new WaitForSeconds(enemyWave.coolDownBetweenBigWave);
        }
    }

}

[Serializable]
public struct Group
{
    public GameObject smallBadGuy;
    public GameObject bigBadGuy;
    public int numberOfSmall;
    public int numberOfBig;
    public float coolDownBetweenSmallEnemies;
    public float coolDownBetweenBigEnemies;
}

[Serializable]
public struct Wave
{
    public Group[] groupOfEnemiesInWave;
    public float coolDownBetweenSmallWave;
    public float coolDownBetweenBigWave;
}

