using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePlatform : MonoBehaviour
{
    private Rigidbody rb;

    //Variable that resets the platform after some time
    [SerializeField] float resetPlatform;

    //The starting position of the falling platform
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
        }
    }
}
