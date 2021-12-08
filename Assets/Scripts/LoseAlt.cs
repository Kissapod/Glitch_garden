using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseAlt : MonoBehaviour
{
    void Update()
    {
        if (transform.childCount <= 0)
        {
            Lose();
        }
    }
    void Lose()
    {
        LevelManager man = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        man.LoadLevel("03b Lose");
    }
}
