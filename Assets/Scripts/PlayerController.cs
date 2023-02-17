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
            this.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Move Left
            this.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            //Jump
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * dashSpeed);
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        isGrounded = true;

        //if (collision.gameObject.tag == "Spring")
        //{

        //    rb.AddForce(Vector3.up * SpringForce, ForceMode.Impulse);
        //}

    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false; 
    }

    private void OnTriggerEnter(Collider deathcollision)
    {
        if (deathcollision.tag == "Water")
        {
            audioplayer.Play();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Game Over");
        }
    }
}


