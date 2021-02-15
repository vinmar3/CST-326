using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 7f;
    public Vector3 startPosition;
    public float step;
    private Rigidbody rb;
    public bool useDebugVisualization;

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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Left Player" || collision.gameObject.name == "Right Player")
        {
            //play sound

            speed += step;
            float heightAboveOrBelow = transform.position.z - collision.transform.position.z;
            float maxHeight = collision.collider.bounds.extents.z;
            float percentOfMax = heightAboveOrBelow / maxHeight;

            if (useDebugVisualization)
            {
                DebugDraw.DrawSphere(transform.position, 0.5f, Color.green);
                DebugDraw.DrawSphere(collision.transform.position, 0.5f, Color.red);
                Debug.Break();
                Debug.Log($"percent height = {percentOfMax}");
            }

            bool hitLeftPaddle = collision.gameObject.name == "PaddleLeft";
            float newHorizontalSpeed = (hitLeftPaddle) ? speed : -speed;

            Vector3 newVelocity = new Vector3(newHorizontalSpeed, 0f, percentOfMax * 4f).normalized * speed;
            rb.velocity = newVelocity;
        }
    }

    private void Launch()
    {
            float x = Random.Range(0, 2) == 0 ? -1 : 1;
            float y = Random.Range(0, 2) == 0 ? -1 : 1;
            GetComponent<Rigidbody>().velocity = new Vector3(speed * x, speed * y, 0f);
    }
}