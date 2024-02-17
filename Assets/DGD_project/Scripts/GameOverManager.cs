using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text scoreText;
    
    public GameObject PowerUp;
    public GameObject BottomPanel;

    private void Start()
    {
        
        gameOverScreen.SetActive(false);
        
    }

    public void ShowGameOverScreen()
    {
        int score = SaveGame.GetScore();
        Debug.Log("Retrieved score:"+ score);

        
        scoreText.text = "Your Score: " + score.ToString();
        gameOverScreen.SetActive(true);

        PowerUp.SetActive(false);
        BottomPanel.SetActive(false);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PowerUp.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

