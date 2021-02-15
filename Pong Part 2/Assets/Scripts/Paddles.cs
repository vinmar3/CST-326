using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddles : MonoBehaviour
{
    public bool LeftPaddle;
    public float speed = 5f;

    public void Update()
    {
         if (LeftPaddle)
         {
               transform.Translate(0f, Input.GetAxis("Left Player") * speed * Time.deltaTime, 0f);
         }
         else
         {
               transform.Translate(0f, Input.GetAxis("Right Player") * speed * Time.deltaTime, 0f);
          }
    }
}
