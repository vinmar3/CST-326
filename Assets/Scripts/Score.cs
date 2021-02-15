using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI LeftScore;
    public TextMeshProUGUI RightScore;

    public int LeftPlayerScore = 0;
    public int RightPlayerScore = 0;

    [Header("Left Player")]
    public GameObject LeftPaddle;
    public GameObject RightGoal;

    [Header("Right Player")]
    public GameObject RightPaddle;
    public GameObject LeftGoal;

    [Header("Power Ups")]
    public GameObject Booster;
    public GameObject Booster2;

    [Header("Ball")]
    public GameObject Ball;

    public void LeftPlayerScored()
    {
        LeftPlayerScore++;
        LeftScore.text = $"{LeftPlayerScore}";

        if (LeftPlayerScore > RightPlayerScore)
        {
            LeftScore.color = Color.green;
            RightScore.color = Color.red;
        }

        else if (LeftPlayerScore < RightPlayerScore)
        {
            LeftScore.color = Color.red;
            RightScore.color = Color.green;
        }

        else
        {
            LeftScore.color = Color.white;
            RightScore.color = Color.white;
        }

        if (LeftPlayerScore == 11)
        {
            Debug.Log($"Game Over, Left Player Wins!");
            ResetGame();
        }
        ResetBall();
        ResetPowerups();
    }

    public void RightPlayerScored()
    {
        RightPlayerScore++;
        RightScore.text = $"{RightPlayerScore}";
        if (LeftPlayerScore < RightPlayerScore)
        {
            RightScore.color = Color.green;
            LeftScore.color = Color.red;
        }

        else if (LeftPlayerScore > RightPlayerScore)
        {
            RightScore.color = Color.red;
            LeftScore.color = Color.green;
        }

        else
        {
            RightScore.color = Color.white;
            LeftScore.color = Color.white;
        }

        if (RightPlayerScore == 11)
        {
            Debug.Log($"Game Over, Right Player Wins!");
            ResetGame();
        }
        ResetBall();
        ResetPowerups();
    }

    private void ResetBall()
    {
        Ball.GetComponent<Ball>().Reset();
    }

    private void ResetPowerups()
    {
        Booster.GetComponent<PowerUp>().Reset();
        Booster2.GetComponent<PowerUp>().Reset();
    }

    private void ResetGame()
    {
        RightPlayerScore = 0;
        LeftPlayerScore = 0;
        RightScore.color = Color.white;
        LeftScore.color = Color.white;
        LeftScore.text = $"{0}";
        RightScore.text = $"{0}";
        Debug.Log($"Game Reset. Score: 0-0");
    }
}
