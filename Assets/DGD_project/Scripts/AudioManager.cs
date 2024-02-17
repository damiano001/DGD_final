using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource musicSource, soundEffectSource;
    [SerializeField] AudioClip  gameMusic, enemyDestroyed, playerDestroyed, PowerUp;
   

    
    private void Awake()
    {
        instance = this;
        musicSource = gameObject.AddComponent<AudioSource>();
        soundEffectSource = gameObject.AddComponent<AudioSource>();
    }

     private void Start()
    {
        musicSource.loop = true;
        musicSource.volume = 0.5f;

         
         bool musicEnabled = SaveGame.GetMusicEnabled();
         bool soundEnabled = SaveGame.GetSoundEnabled();

          if (musicEnabled)
        {
           PlayGameMusic();
        }
        else
        {
            StopGameMusic();
        }        
    }    
    

    public void PlayGameMusic()
    {
        musicSource.clip = gameMusic;
        musicSource.Play();
    }
    
    public void StopGameMusic()
    {
    if (musicSource.clip == gameMusic && musicSource.isPlaying)
    {
        musicSource.Stop();
    }
    }
    
    public void PlayDefeatSound()
    {
        if (SaveGame.GetSoundEnabled())
        {
            soundEffectSource.PlayOneShot(playerDestroyed);
        }
    }

    public void PlayEnemyDestroySound()
    {
        if (SaveGame.GetSoundEnabled())
        {
            soundEffectSource.PlayOneShot(enemyDestroyed);
        }
    }
   
      public void PlayPowerUp()
    {
        if (SaveGame.GetSoundEnabled())
        {
            soundEffectSource.PlayOneShot(PowerUp);
        }
    }

    

}


