using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3;
    public float timer = 5f;
    public GameObject bullet;
    public GameObject shot;
    private Animator playerAnimator;
    private AudioSource audioSource;
    public AudioClip playerShoot;
    public AudioClip playerBoom;

    public Transform shootingOffset;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(transform.right * horizontal * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && shot == null)
        {
            playerAnimator.SetTrigger("Shoot");
            audioSource.PlayOneShot(playerShoot);
            shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
            Destroy(shot, 1.9f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "EnemyBullet(Clone)")
        {
            PlayerDead();
        }
    }
    public void PlayerDead()
    {
        playerAnimator.SetTrigger("Boom");
        audioSource.PlayOneShot(playerBoom);
        Destroy(gameObject, 2f);
    }

    public void ToCreditScene()
    {
        GameObject.Find("ToCredits").GetComponent<MainMenu>().Credits();
    }
}
