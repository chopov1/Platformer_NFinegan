using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] int jumpHeight;
    [SerializeField] int dashSpeed = 20;
    [SerializeField] float score;
    [SerializeField] int sprintHeight = 30;
    [SerializeField] float jumpForce;
    [SerializeField] AudioSource audioplayer;

    Rigidbody rb;

    bool canJump;
    bool isJumping = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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

        if (isJumping == true && Input.GetKeyDown(KeyCode.Space))
        {
            //Jump
            //dojump = true;
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.right * Time.deltaTime * dashSpeed);           
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }

    }


    private void FixedUpdate()
    {
        if (isJumping && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
            canJump = false;
        }

    }


    private void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "Water")
        {
            audioplayer.Play();
            //need to add a delay to game over so you can hear sound effect before reset
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Game Over");
        }


        if (collision.gameObject.CompareTag("Coin"))
        {
            score++;
            collision.gameObject.SetActive(false);
            Debug.Log($"Score: {score}");
            Instantiate(collision.gameObject);
        }

        //Collision with spring forces player into the air
        if (collision.gameObject.CompareTag("Spring"))
        {
            rb.AddForce(Vector3.up * sprintHeight, ForceMode.Impulse);
        }
    }
}


