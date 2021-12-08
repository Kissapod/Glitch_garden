using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mina : Shooter
{
    void Start()
    {
        animator = GetComponent<Animator>();
        SetMyLaneSpawner();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        if (attacker)
        {
            if (attacker.GetComponent<JumpAttacker>())
            {
                if (attacker.GetComponent<JumpAttacker>().jumpActivity)
                    return;
            }
            Instantiate(projectile, transform.position, Quaternion.identity);
            FindObjectOfType<DefenderSpawner>().DestroyDef(gameObject);
            Destroy(gameObject);
        }
    }
}
