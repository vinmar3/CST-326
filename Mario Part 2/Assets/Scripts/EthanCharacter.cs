using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class EthanCharacter : MonoBehaviour
{
    private Animator animator;
    public Rigidbody rb;
    public float modifier = 3;
    public float jumpForce = 1;
    [Range(-2, 2)] public float speed = 0;
    private bool jump = false;
    private bool turbo = false;
    public GameObject player;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Brick(Clone)")
        {
            GameObject.Find("UI").GetComponent<Game>().ScoreUI();
            Destroy(collider.gameObject);
        }
        if(collider.gameObject.name == "QuestionBox(Clone)")
        {
            GameObject.Find("UI").GetComponent<Game>().CoinUI();
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.name == "Goal(Clone)")
        {
            GameObject.Find("UI").GetComponent<Game>().GameUI();
            GetComponent<Animator>().enabled = false;
            GetComponent<EthanCharacter>().enabled = false;
            GameObject.Find("Music").GetComponent<AudioSource>().enabled = false;

        }
        if (collider.gameObject.name == "Enemy(Clone)" || collider.gameObject.name == "Lava(Clone)")
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        jump = (Input.GetKeyDown(KeyCode.Space)) ? true : false;
        turbo = (Input.GetKey(KeyCode.LeftShift)) ? true : false;

        //Set character rotation
        float y = (horizontal < 0) ? 270 : 90;
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, y, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;

        //Set character animation
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        //move character
        transform.Translate(-transform.right * horizontal * modifier * Time.deltaTime);
    
    }

    void FixedUpdate()
    {
        if (jump) rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
        if (turbo)
        {
            modifier = 6;
        }
        else if(turbo == false)
        {
            modifier = 3;
        }
    }
}
