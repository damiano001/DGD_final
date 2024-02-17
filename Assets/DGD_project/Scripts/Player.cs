using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject destructionFX;
    public int score;
    public static Player instance; 
    
    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }
   
    public void GetDamage(int damage)   
    {
        Destruction();
    }    
   
   void Destruction()
   {
    GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
    if (gameOverManager != null)
    {
        gameOverManager.ShowGameOverScreen();
    }
    AudioManager.instance.PlayDefeatSound();
    Instantiate(destructionFX, transform.position, Quaternion.identity); 
    Destroy(gameObject);
    
    AudioManager.instance.StopGameMusic();
    }

}
















