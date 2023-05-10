using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class StartButton : MonoBehaviour
{
    //public TextMeshProUGUI buttonText;

    //private void Start()
    //{
    //    buttonText.text = "Start Game";
    //}

    //public void OnButtonClick()
    //{
    //    SceneManager.LoadScene("LevelOne"); 
    //}
    public string sceneName;
    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
