using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrofyStar : MonoBehaviour
{
    public float timeStarBirth;
    public GameObject star;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeStarBirth && GetComponentsInChildren<Star>().Length < 2)
        {
            timer = 0;
            Instantiate(star, transform.position, Quaternion.identity, transform);
        }
    }
}
