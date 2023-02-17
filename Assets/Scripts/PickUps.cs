using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    private int points;

    private void OnTriggerEnter(Collider itemcollision)
    {
        if (itemcollision.tag == "Player")
        {
            //Disable item
            gameObject.SetActive(false);
            //Recieve point
            
           
        }
        points++;
        Debug.Log($"Score: {points} ");
        

    }
}
