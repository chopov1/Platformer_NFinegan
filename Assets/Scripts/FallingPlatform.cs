using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float fallTimer = 1f;
    Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallTimer);
        }
    }

    void Fall()
    {
        rb.isKinematic = false;
    }
}
