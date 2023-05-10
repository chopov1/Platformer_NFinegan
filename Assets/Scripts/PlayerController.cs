using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Player movement speed
    [SerializeField] int speed;

    //Player jump height
    [SerializeField] int jumpHeight;

    //Player dash speed
    [SerializeField] int dashSpeed = 20;

    //Score tracker
    [SerializeField] float score;

    //Player spring height
    [SerializeField] int springHeight = 30;

    //Audio Player for background and other audio sources
    [SerializeField] AudioSource audioplayer;

    //Checks if player is connected with the ground
    private bool isGrounded = false;

    //Player rigidbody
    Rigidbody rb;

    //Reference to the Score UI
    public UIScore uiScore;

    //Audio Source for jump sound
    public AudioSource jumpSound;

    //Audio source for coin sound
    public AudioSource coinSound;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        uiScore = GameObject.FindObjectOfType<UIScore>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //Move Right
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Move Left
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetAxis("Jump") > 0 && isGrounded == true)
        {
            //Jump
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
            jumpSound.Play();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {

            if (Input.GetAxisRaw("Horizontal") != 0f)
            {
                // Dash left or right based on whcih way the player is facing
                transform.Translate(Vector3.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * dashSpeed);
            }
        }
    }


    private void FixedUpdate()
    {
        // Check if player is touching the ground
        RaycastHit collided;
        if (Physics.Raycast(transform.position, -Vector3.up, out collided, 1.1f))
        {
            isGrounded = true;
        }

        //If the player is not grounded
        //Allow them to jump again
        if (!isGrounded)
        {
            rb.AddForce(Vector3.down * 10f);
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        // If the player collides or falls into water
        //The water droplet sound will player
        //And the player dies and the game resets
        //note: compare tag 
        if (collision.tag == "Water")
        {
            audioplayer.Play();
            //Adds a .5 second delay before calling the ResetScene Methood
            Invoke("ResetScene", .5f);
        }
        if (collision.tag == "Spike")
        {
            //Adds a .5 second delay before calling the ResetScene Methood
            Invoke("ResetScene", .2f);
        }


        //If the player collides/collects a coin
        //their score will be increased
        //and the coin game Object will disappear from the scene
        if (collision.gameObject.CompareTag("Coin"))
        {
            score++;
            collision.gameObject.SetActive(false);
            Instantiate(collision.gameObject);
            uiScore.Score = score;
            coinSound.Play();

        }




        //Collision with spring forces player into the air
        if (collision.gameObject.CompareTag("Spring"))
        {
            rb.AddForce(Vector3.up * springHeight, ForceMode.Impulse);
        }
    }

    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Game Over");
    }
}


