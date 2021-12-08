using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float fadeInTime; //задаем публичную переменную для изменения времени появления меню
    public Color currentColor;
    private Image fadePanel;
    // Start is called before the first frame update
    void Start()
    {
        fadePanel = GetComponent<Image>(); //присваиваем перемененной фэйдпанел компонент Имэйдж
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad < fadeInTime)  //если время прошедшее с момента загрузки уровня меньше заданного времени загрузки, то делаем плавное появление
        {
            float alphaChange = Time.deltaTime / fadeInTime; // делим дельтатайм (примерно 50мс) на время появления
            currentColor.a -= alphaChange; // вычитаем из альфы полученную переменную
            fadePanel.color = currentColor; // присваиваем цвету панели обновленный цвет
        } else
        {
            gameObject.SetActive(false); //деактивируем объект панели (как будто снимаем галочку)
        }
    }
}
