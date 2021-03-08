using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI hiScore;
    public int score;
    public int hiscore;

    void Start()
    {
        score = 0;
        hiscore = 0;
        Score.text = $"SCORE \r\n  000" + score;
        hiScore.text = $"HI-SCORE \r\n     000" + hiscore;
    }

    public void Enemy1Points()
    {
        score += 10;
        ScoreUI();
    }
    public void Enemy2Points()
    {
        score += 20;
        ScoreUI();
    }
    public void Enemy3Points()
    {
        score += 30;
        ScoreUI();
    }
    public void Enemy4Points()
    {
        score += 40;
        ScoreUI();
    }

    void ScoreUI()
    {
        if (score >= 10 && score <= 99)
        {
            Score.text = $"SCORE \r\n  00" + score;
            if (score > hiscore)
            {
                hiscore = score;
                hiScore.text = $"HI-SCORE \r\n     00" + hiscore;
            }
        }
        else if (score >= 100 && score <= 999)
        {
            Score.text = $"SCORE \r\n  0" + score;
            if (score > hiscore)
            {
                hiscore = score;
                hiScore.text = $"HI-SCORE \r\n     0" + hiscore;
            }
        }
        else if (score >= 1000 && score <= 9999)
        {
            Score.text = $"SCORE \r\n  " + score;
            if (score > hiscore)
            {
                hiscore = score;
                hiScore.text = $"HI-SCORE \r\n     " + hiscore;
            }
            if (score >= 9999)
            {
                score = 9999;
                Score.text = $"SCORE \r\n  " + score;
                hiscore = score;
                hiScore.text = $"HI-SCORE \r\n     " + hiscore;
            }
        }
    }
}
