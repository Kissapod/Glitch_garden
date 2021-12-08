using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour
{
    public int starCoast = 10;
    public float powerDef;
    
    private StarDisplay starDisplay;
    private Vector2 positionDefender;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>(); //находим скрипт в нашем игровом пространстве
        positionDefender = transform.position;
    }

    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount); //находим метод ДОБАВИТЬЗВЕЗДЫ в скрипте ЗВЕЗДНЫЙДИСПЛЕЙ и отправляем туда значение int
    }

    void OnMouseDown()
    {
        if (Button.selectedDefender.GetComponent<Shovel>() && !CompareTag("noDestroy"))
        {
            GameObject defender = Button.selectedDefender;
            SpawnDefender(positionDefender, defender);
            FindObjectOfType<DefenderSpawner>().DestroyDef(gameObject); // вычетаем мощь защитников
            Destroy(gameObject);
        } 
    }
    void SpawnDefender(Vector2 positionDefender, GameObject defender)
    {
        Quaternion zeroRot = Quaternion.identity;
        Instantiate(defender, positionDefender, zeroRot);
    }
}
