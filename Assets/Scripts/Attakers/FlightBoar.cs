using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightBoar : MonoBehaviour
{
    public GameObject boom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (!obj.GetComponent<Defenders>() || obj.GetComponent<Shovel>()) //если у объекта нет скрипта защитника, то мы выходим из метода
            return;
        else
        {
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
