using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    public float fadeInTime =2f; //задаем публичную переменную для изменения времени появления меню

    void Update()
    {
        if (Time.timeSinceLevelLoad < fadeInTime)  //если время прошедшее с момента загрузки уровня меньше заданного времени загрузки, то делаем плавное появление
        {
          
        } else { 
            gameObject.SetActive(false); //деактивируем объект панели (как будто снимаем галочку)
        }
    }
}
