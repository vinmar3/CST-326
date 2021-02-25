using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    public float startTime = 999;
    public float currentTime;
    public bool start;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        Timer.text = $"TIME \r\n {Math.Round(currentTime)}";
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            currentTime -= Time.deltaTime;
            Timer.text = $"TIME \r\n {Math.Round(currentTime)}";
        }
    }
}
