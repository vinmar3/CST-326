using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI hiScore;
    public int score;
    public int hiscore = 0;

    void Start()
    {
        score = 0;
        Score.text = $"SCORE \r\n  000" + score;
        if (PlayerPrefs.GetInt("Highscore") == 0)
        {
            hiScore.text = $"HI-SCORE \r\n    000" + PlayerPrefs.GetInt("Highscore");
        }
        else if (PlayerPrefs.GetInt("Highscore") >= 10 && PlayerPrefs.GetInt("Highscore") <= 99)
        {
            hiScore.text = $"HI-SCORE \r\n    00" + PlayerPrefs.GetInt("Highscore");
        }
        else if (PlayerPrefs.GetInt("Highscore") >= 100 && PlayerPrefs.GetInt("Highscore") <= 999)
        {
            hiScore.text = $"HI-SCORE \r\n    0" + PlayerPrefs.GetInt("Highscore");
        }
        else if (PlayerPrefs.GetInt("Highscore") >= 1000 && PlayerPrefs.GetInt("Highscore") <= 9999)
        {
            hiScore.text = $"HI-SCORE \r\n    " + PlayerPrefs.GetInt("Highscore");
        }
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
        PlayerPrefs.GetInt("Highscore");
        if (score >= 10 && score <= 99)
        {
            Score.text = $"SCORE \r\n  00" + score;
 
            if (score > PlayerPrefs.GetInt("Highscore"))
            {
                hiscore = score;
                PlayerPrefs.SetInt("Highscore", hiscore);
                hiScore.text = $"HI-SCORE \r\n    00" + hiscore;
            }
        }
        else if (score >= 100 && score <= 999)
        {
            Score.text = $"SCORE \r\n  0" + score;
            PlayerPrefs.GetInt("Highscore");
            if (score > PlayerPrefs.GetInt("Highscore"))
            {
                hiscore = score;
                PlayerPrefs.SetInt("Highscore", hiscore);
                hiScore.text = $"HI-SCORE \r\n    0" + hiscore;
            }
        }
        else if (score >= 1000 && score <= 9999)
        {
            Score.text = $"SCORE \r\n  " + score;
            PlayerPrefs.GetInt("Highscore");
            if (score > PlayerPrefs.GetInt("Highscore"))
            {
                hiscore = score;
                PlayerPrefs.SetInt("Highscore", hiscore);
                hiScore.text = $"HI-SCORE \r\n    " + hiscore;
            }
            if (score >= 9999)
            {
                score = 9999;
                Score.text = $"SCORE \r\n  " + score;
                hiscore = score;
                PlayerPrefs.SetInt("Highscore", hiscore);
                hiScore.text = $"HI-SCORE \r\n    " + hiscore;
            }
        }
    }
}
