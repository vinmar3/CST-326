using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 7f;
    public Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        Launch();
    }

    public void Reset()
    {
        transform.position = startPosition;
        Launch();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Right Goal"))
        {
            float x = Random.Range(0, 2) == 0 ? 1 : 1;
            float y = Random.Range(0, 2) == 0 ? -1 : 1;
            GetComponent<Rigidbody>().velocity = new Vector3(speed * x, speed * y, 0f);
        }
        else if (collision.gameObject.CompareTag("Left Goal"))
        {
            float x = Random.Range(0, 2) == 0 ? -1 : -1;
            float y = Random.Range(0, 2) == 0 ? -1 : 1;
            GetComponent<Rigidbody>().velocity = new Vector3(speed * x, speed * y, 0f);
        }
    }

    private void Launch()
    {
            float x = Random.Range(0, 2) == 0 ? -1 : 1;
            float y = Random.Range(0, 2) == 0 ? -1 : 1;
            GetComponent<Rigidbody>().velocity = new Vector3(speed * x, speed * y, 0f);
    }
}