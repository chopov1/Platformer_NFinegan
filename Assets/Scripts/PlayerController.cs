using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Player movement speed
    [SerializeField] int speed;

    //Player dash force
    [SerializeField, Tooltip("Adjust this as needed when changing physics settings")] 
    int dashForce;

    //Score tracker
    [SerializeField] float score;

    //Player spring height
    [SerializeField, Tooltip("How intense the gravity is. Higher number = more gavity")] 
    int gravityScale = 30;

    //Player spring height
    [SerializeField]
    int springHeight = 30;

    //Audio Player for background and other audio sources
    [SerializeField] AudioSource audioplayer;

    //Checks if player is connected with the ground
    private bool isGrounded = false;

    //Player rigidbody
    Rigidbody rb;

    //Reference to the Score UI
    public UIScore uiScore;

    //Audio Source for jump sound
    public AudioClip jumpSound;

    //Audio source for coin sound
    public AudioClip coinSound;

    bool currentBeatHasInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        uiScore = GameObject.FindObjectOfType<UIScore>();
    }

    protected bool OnBeat()
    {
        return RhythmManager.Instance.IsOnBeat();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
        if(!OnBeat())
        {
            currentBeatHasInput = false;
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
            rb.AddForce(Vector3.down * gravityScale);
        }

    }

    private void CheckMovement()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (canMove())
            {
                rb.AddForce(Vector3.right * dashForce, ForceMode.Impulse);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (canMove())
            {
                rb.AddForce(Vector3.left * dashForce, ForceMode.Impulse);
            }
        }
        if (Input.GetKey(KeyCode.W) && isGrounded == true)
        {
            if (canMove())
            {
                rb.AddForce(Vector3.up * (dashForce / 2), ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

    private bool canMove()
    {
        if(!currentBeatHasInput && OnBeat())
        {
            currentBeatHasInput = true;
            return true;
        }
        return false;
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
            //coinSound.Play();

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


