using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Defenders>())
        {
            FindObjectOfType<DefenderSpawner>().DestroyDef(collision.gameObject);
        }
        Destroy(collision.gameObject);
    }
}
