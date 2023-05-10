using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;

    public void gameOver()
    {
        // Activate the game over UI
        gameOverUI.SetActive(true);

    }

    public void RestartScene()
    {
        // Reload first scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
