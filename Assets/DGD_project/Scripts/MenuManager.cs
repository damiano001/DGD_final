using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Toggle musicToggle;
    [SerializeField] Toggle soundToggle;

    private void Start()
    {
       
        musicToggle.isOn = SaveGame.GetMusicEnabled();
        soundToggle.isOn = SaveGame.GetSoundEnabled();
    }
    
   public void PlayNewGame(int i)
    {
        
        AsyncOperation op = SceneManager.LoadSceneAsync(i);
        
    }

    public void Exit()
    {
        Application.Quit();
    }

     public void ToggleMusic()
    {
        SaveGame.SaveMusicEnabled(musicToggle.isOn);
    }

    public void ToggleSound()
    {
        SaveGame.SaveSoundEnabled(soundToggle.isOn);
    }
}
