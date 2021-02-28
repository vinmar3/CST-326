using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI Coins;
    public TextMeshProUGUI Score;
    public float startTime;
    public float currentTime;
    public bool start;
    public int startScore = 0;
    public int startCoin = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        Timer.text = $"TIME \r\n {Math.Round(currentTime)}";
        start = true;
        Score.text = $"SCORE \r\n {startScore}";
        Coins.text = $"x{startCoin}";
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            currentTime -= Time.deltaTime;
            Timer.text = $"TIME \r\n {Math.Round(currentTime)}";
            if (Math.Round(currentTime) == 0)
            {
                Debug.Log("You Failed. Game Over");
                currentTime = 0;
                start = false;
                GameObject.Find("Ethan").GetComponent<Animator>().enabled = false;
                GameObject.Find("Ethan").GetComponent<EthanCharacter>().enabled = false;
                GameObject.Find("Music").GetComponent<AudioSource>().enabled = false;
            }
        }
    }

    public void ScoreUI()
    {
        startScore += 100;
        Score.text = $"SCORE \r\n {startScore}";
    }

    public void CoinUI()
    {
        startScore += 100;
        startCoin += 1;
        Coins.text = $"x{startCoin}";
        Score.text = $"SCORE \r\n {startScore}";
    }

    public void GameUI()
    {
        Debug.Log("Congratulations! You finished the level!");
        start = false;
        Score.text = $"SCORE \r\n {startScore}";
        Timer.text = $"TIME \r\n {Math.Round(currentTime)}";
        Coins.text = $"x{startCoin}";
    }
}
