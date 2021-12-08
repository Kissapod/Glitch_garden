using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public Camera myCamera;
    public static float powerDef;

    private GameObject parent;
    private StarDisplay starDisplay;
    private GameObject starNull;
    private Animator animStarNull;

    private void Start()
    {
        powerDef = 0;
        parent = GameObject.Find("Defenders");
        starNull = GameObject.Find("Star Null");
        animStarNull = starNull.GetComponent<Animator>();
        animStarNull.enabled = false;
        starNull.SetActive(false);
        starDisplay = FindObjectOfType<StarDisplay>();
        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
    }
    void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointOfMouseClick(); // создаем переменную типа Вектор 2, которой присваиваем значения координат из метода
        Vector2 roundedPos = SnapToGrid(rawPos); // создаем переменную типа вектор 2, которой присваиваем значения координат из метода SnapToGrid, в который сперва передаем значения переменной rawPos
        GameObject defender = Button.selectedDefender; //создаем переменную типа игровой объект, которому присваиваем значение публичной СТАТИЧЕСКОЙ переменной из скрипта Button
        if (defender && !defender.GetComponent<Shovel>() && !StopGame.pause && !GameTimer.isEndWinCondition) {
            int defenderCost = defender.GetComponent<Defenders>().starCoast;
            if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS) { 
                SpawnDefender(roundedPos, defender);
            } else
            {
                if (starNull && !animStarNull.enabled) { //проверяем условие если анимация не активна , то
                starNull.SetActive(true); //включаем текст
                animStarNull.enabled = true; //включаем анимацию
                Invoke("FaidIn", 1.5f);
                } else
                {
                    return;
                }
            }
        }
    }
    void SpawnDefender(Vector2 roundedPos, GameObject defender)
    {
        Quaternion zeroRot = Quaternion.identity;
        powerDef += defender.GetComponent<Defenders>().powerDef;
        GameObject newDef = Instantiate(defender, roundedPos, zeroRot);
        newDef.transform.parent = parent.transform;
    }
    //создаем метод для округления координат. во время нажатия мыши, он принимает дробные координаты и переводит их в целые значения
    Vector2 SnapToGrid (Vector2 rawWorldPos) //принимает координаты типа вектора 2. в скобках этот вектор называется rawWorldPos
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x); //с помощью команды RoundToInt округляем значение координтаты в мировых единицах
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY); //возвращает новый вектор 2 с новыми координатами
    }
    Vector2 CalculateWorldPointOfMouseClick ()
    {
        float mouseX = Input.mousePosition.x; //передаем координаты мыши в переменные
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f; // создаем переменную дистанция от камеры
       
        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera); //создаем переменную вектор 3 с координатами мыши
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet); // создаем переменную вектор 2, в которой координаты Вектора3 переводятся в мировые координаты
        return worldPos; // возвращаем мировые координаты мыши
    }
    void FaidIn()
    {
        animStarNull.enabled = false;
        starNull.SetActive(false);
    }

    public void DestroyDef(GameObject defender)
    {
        powerDef -= defender.GetComponent<Defenders>().powerDef;
    }
}
