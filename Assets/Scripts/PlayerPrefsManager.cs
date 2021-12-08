using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "masterVolume"; //постоянная строчная переменная громкости 
    const string DIFFICULTY_KEY = "difficulty"; //постоянная строчная переменная чувствительности
    const string LEVEL_KEY = "level_unlocked_"; //постоянная строчная переменная разблокировки уровней

    public static void SetMasterVolume (float volume) //создаем публичный метод в который передается значение громкости
    {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume); // заносим значение громкости в переменную мастер волюм и передаем в настройки игрока
        } else {
            Debug.LogError("Значение громкости вне диапазона");
        }
    }
    public static float GetMasterVolume() //создаем метод возвращающий значение ключа из настроек.
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY); //возвращаем значение из настроек игрока через ключ
    }

    public static void UnlockLevel(int level) 
    {
        if (level <= SceneManager.sceneCountInBuildSettings)  
        {
            PlayerPrefs.SetInt(LEVEL_KEY, level);
        }
        else
        {
            Debug.LogError("Значение уровня вне билда");
        }
    }

    public static bool LevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY);
        if (level <= levelValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static int LevelUnlocked()
    {
        return PlayerPrefs.GetInt(LEVEL_KEY);
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        } else
        {
            Debug.LogError("Значение сложности вне диапазона");
        }
    }

    public static float GetDifficulty ()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}

