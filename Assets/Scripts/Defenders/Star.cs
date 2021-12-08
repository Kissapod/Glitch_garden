using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public int starPrice = 10;
    public float speed = 0.01f;

    private StarDisplay starDisplay;
    // Start is called before the first frame update
    void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator moveYToZero()
    {
        Debug.Log("Start coroutine");
        Vector3 startPos = transform.position; // запоминаем начальную позицию
        Vector3 endPos = starDisplay.transform.position; // запоминаем нужную конечную позицию
//  скорость прогресса (от начальной до конечной позиции)
        float progress = 0;
        while (true)
        {
            progress += speed;
            transform.position = Vector3.Lerp(startPos, endPos, progress);
            if (progress > 1) 
            {
                starDisplay.AddStars(starPrice);
                Destroy(gameObject);
                yield break;                // выход из корутины, если находимся в конечной позиции
            }
            yield return null; // если выхода из корутины не произошло, то продолжаем выполнять цикл while в следующем кадре
        }
    }

    private void OnMouseEnter()
    {
        GetComponent<Animator>().enabled = false;
        StartCoroutine("moveYToZero");
    }
}
