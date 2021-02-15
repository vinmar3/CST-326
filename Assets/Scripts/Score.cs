using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int LeftPlayerScore = 0;
    private int RightPlayerScore = 0;

    [Header("Left Player")]
    public GameObject LeftPaddle;
    public GameObject RightGoal;

    [Header("Right Player")]
    public GameObject RightPaddle;
    public GameObject LeftGoal;

    [Header("Ball")]
    public GameObject Ball;

    public void LeftPlayerScored()
    {
        LeftPlayerScore++;
        Debug.Log($"Left Player has scored! {LeftPlayerScore}-{RightPlayerScore}");
        if (LeftPlayerScore == 11)
        {
            Debug.Log($"Game Over, Left Player Wins!");
            ResetGame();
        }
        ResetBall();
    }

    public void RightPlayerScored()
    {
        RightPlayerScore++;
        Debug.Log($"Right Player has scored! {LeftPlayerScore}-{RightPlayerScore}");
        if (RightPlayerScore == 11)
        {
            Debug.Log($"Game Over, Right Player Wins!");
            ResetGame();
        }
        ResetBall();
    }

    private void ResetBall()
    {
        Ball.GetComponent<Ball>().Reset();
    }

    private void ResetGame()
    {
        RightPlayerScore = 0;
        LeftPlayerScore = 0;
        Debug.Log($"Game Reset. Score: 0-0");
    }
}
