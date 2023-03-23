using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code help from Stuart Spence (Youtube)

public class FallingPlatform : MonoBehaviour
{
    //Variable that delays how long it takes between player and platform collision
    [SerializeField] float fallTimer = 1f;
    //Variable that resets the platform after some time
    [SerializeField] float resetPlatform;

    //The starting position of the falling platform
    private Vector3 startingPosition;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingPosition = transform.position;
        //kinematic needs to be coded here
        //kinematic not available for 3D gameObject when comparing to 2D ones
        rb.isKinematic = true;
    }

    void Fall()
    {
        rb.isKinematic = false;
        //call reset method here
    }

    private void Reset()
    {
        //reset platform code goes here
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //invoked only when the gameobject with the player tag collides
            Invoke("Fall", fallTimer); 
        }
    }


}
