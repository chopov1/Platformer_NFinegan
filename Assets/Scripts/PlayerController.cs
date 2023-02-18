using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] int jumpHeight;
    [SerializeField] int dashSpeed = 20;
    [SerializeField] AudioSource audioplayer;
    private bool isGrounded = false;
    Rigidbody rb;

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
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            //Jump
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.right * Time.deltaTime * dashSpeed);
            
            
        }
        //if Mouse1 is clicks = dash to nearest enemy

    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }


    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false; 
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "Water")
        {
            audioplayer.Play();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Game Over");
        }
        
    }
}


