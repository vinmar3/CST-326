using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3;
    public GameObject bullet;

  public Transform shottingOffset;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(transform.right * horizontal * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);

        Destroy(shot, 3f);
        }
    }
}
