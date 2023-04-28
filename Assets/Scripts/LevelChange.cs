using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public string sceneChange = "LevelTwo";
    public string _sceneChange = "LevelThree";

    private void OnTriggerEnter(Collider other)
    {
        // Check if colliding object is player
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("LevelTwo"))
        {
            //Load the specified scene
            SceneManager.LoadScene(_sceneChange);
        }

        // Check if colliding object is player
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("LevelThree"))
        {
            //Load the specified scene
            SceneManager.LoadScene(_sceneChange);
        }


    }
}
