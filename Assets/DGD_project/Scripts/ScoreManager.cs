using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] int score;
    [SerializeField] Text value;
   
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SaveGame.SaveScore(0);
        score = SaveGame.GetScore();
        RenderScore();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        RenderScore();
        SaveScore(); 
    }

    public void SaveScore()
    {
        SaveGame.SaveScore(score);
    }

    private void RenderScore()
    {
        value.text = score.ToString();
    }
}

