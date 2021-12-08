using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawnerClear = true;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Attacker>())
        {
            spawnerClear = false;
            Invoke("SpawnerOn", 0.5f);
        }
    }

    private void SpawnerOn()
    {
        spawnerClear = true;
    }
}
