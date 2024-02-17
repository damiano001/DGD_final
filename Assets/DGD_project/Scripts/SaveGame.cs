using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveGame
{
    
    private const string MusicEnabledKey = "MUSIC_ENABLED";
    private const string SoundEnabledKey = "SOUND_ENABLED";

    public static void SaveScore(int score)
    {
        PlayerPrefs.SetInt("SCORE", score);
        PlayerPrefs.Save();
        
    }  
    public static int GetScore()
    {
        return PlayerPrefs.GetInt("SCORE");
    }



       public static void SaveMusicEnabled(bool enabled)
    {
        PlayerPrefs.SetInt(MusicEnabledKey, enabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static void SaveSoundEnabled(bool enabled)
    {
        PlayerPrefs.SetInt(SoundEnabledKey, enabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static bool GetMusicEnabled()
    {
        return PlayerPrefs.GetInt(MusicEnabledKey, 1) == 1;
    }

    public static bool GetSoundEnabled()
    {
        return PlayerPrefs.GetInt(SoundEnabledKey, 1) == 1;
    }
}
