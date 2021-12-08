using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject defenderPrefab;
    public static GameObject selectedDefender; //статичный обозначает, что переменная существует в единственном экземпляре
    
    private Button[] buttonArray;
    private Text costText;
    // Start is called before the first frame update
    void Start()
    {
        buttonArray = FindObjectsOfType<Button>();
        costText = GetComponentInChildren<Text>();
        if (!costText) 
            Debug.LogError(name + " отсутствует текст со стоимостью"); 
        else
            costText.text = defenderPrefab.GetComponent<Defenders>().starCoast.ToString();
    }

    private void OnMouseDown()
    {
        if (!StopGame.pause)
        {
            foreach (Button thisButton in buttonArray)
            {
                thisButton.GetComponent<SpriteRenderer>().color = Color.black;
            }
            GetComponent<SpriteRenderer>().color = Color.white;
            selectedDefender = defenderPrefab;
       }
    }
}
