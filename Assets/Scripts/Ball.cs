using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEngine;

public enum GameTag
{
    Wall,
    LeftPlayer,
    RightPlayer,
    LeftGoal,
    RightGoal, 
}

public class Ball : MonoBehaviour
{
    public float speed = 7f;
    public float startSpeed = 7f;
    public float step = 1f;
    public Vector3 startPosition;
    private Rigidbody rb;
    private AudioSource audioSource;
    public AudioClip paddleCollision;
    public AudioClip goalCollision;
    public AudioClip wallCollision;
    public AudioClip powerupCollision;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        startPosition = transform.position;
        Launch();
    }

    public void BallRandom()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector3(speed * x, speed * y, 0f);
    }

    public void Reset()
    {
        GetComponent<Renderer>().enabled = true;
        speed = startSpeed;
        transform.position = startPosition;
        Launch();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Left Player" || collision.gameObject.name == "Right Player")
        {
            if(collision.gameObject.tag == (GameTag.LeftPlayer.ToString()) || collision.gameObject.tag == (GameTag.RightPlayer.ToString()))
            {
                audioSource.PlayOneShot(paddleCollision);
            }

            speed += step;
            float heightAboveOrBelow = transform.position.y - collision.transform.position.y;
            float maxHeight = collision.collider.bounds.extents.y;
            float percentOfMax = heightAboveOrBelow / maxHeight;

            bool hitLeftPaddle = collision.gameObject.name == "Left Player";
            float newHorizontalSpeed = (hitLeftPaddle) ? speed : -speed;

            Vector3 newVelocity = new Vector3(newHorizontalSpeed, percentOfMax * 4f, 0f).normalized * speed;
            rb.velocity = newVelocity;
        }

        if (collision.gameObject.name == "Wall")
        {
            if (collision.gameObject.tag == (GameTag.Wall.ToString()))
            {
                audioSource.PlayOneShot(wallCollision);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("RightGoal"))
        {
            audioSource.PlayOneShot(goalCollision);
            float x = Random.Range(0, 2) == 0 ? 1 : 1;
            float y = Random.Range(0, 2) == 0 ? -1 : 1;
            rb.velocity = new Vector3(speed * x, speed * y, 0f);
        }
        else if (collider.gameObject.CompareTag("LeftGoal"))
        {
            audioSource.PlayOneShot(goalCollision);
            float x = Random.Range(0, 2) == 0 ? -1 : -1;
            float y = Random.Range(0, 2) == 0 ? -1 : 1;
            rb.velocity = new Vector3(speed * x, speed * y, 0f);
        }
        else if (collider.gameObject.CompareTag("PowerUp"))
        {
            audioSource.PlayOneShot(powerupCollision);
        }
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector3(speed * x, speed * y, 0f);
    }
}

