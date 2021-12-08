using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] levelMusicChangeArray; //создаем массив из клипов, куда будем загружить нашу музыку
    private AudioSource audioSource; //создаем переменную для получения компонента аудиосорс
    
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject); // не уничтожаем объект при загрузке уровня
        Debug.Log("Не уничтожать при загрузке: " + name);
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); //присваиваем переменной компонент аудиосорс
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }
    
    // Update is called once per frame
    void OnLevelWasLoaded(int level)
    {
        int newLevel = level; 
        AudioClip thisLevelClip = levelMusicChangeArray[level] ; //создаем переменную типа аудиоклип зислевелклип, которой присваиваем позицию клипа в массиве
        Debug.Log("Играет клип: " + thisLevelClip);
        if (thisLevelClip && thisLevelClip != audioSource.clip) //если в этой позиции загружена мелодия, то 
        {
            audioSource.clip = thisLevelClip; //аудиосорсу присваивается загруженная мелодия
            audioSource.loop = true; //включаем зацикливание мелодии
            audioSource.Play(); //запускаем воспроизведение
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
