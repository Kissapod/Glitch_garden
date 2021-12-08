using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;
    //[SerializeField] private Color health75Procent;
    private Animator anim;
    private bool cook;
    private float health75Proc;
    private float health50Proc;
    private float health25Proc;
    private SpriteRenderer colorSprite;

    private void Start()
    {
        anim = GetComponent<Animator>();
        health75Proc = health * 0.75f;
        health50Proc = health * 0.5f;
        health25Proc = health * 0.25f;
        colorSprite = GetComponentInChildren<SpriteRenderer>();
    }
    public void DealDamage (float damage)
    {
        health -= damage;
        /*if (health < health25Proc) 
            colorSprite.color = new Color (0.65f, 0.65f, 0.65f);
        else if (health < health50Proc)
            colorSprite.color = new Color(0.7f, 0.7f, 0.7f);
        else if (health < health75Proc)
            colorSprite.color = new Color(0.85f, 0.85f, 0.85f);*/
        if (health <= 0)
            DestroyObject();
    }
    public void DestroyObject()
    {
        if (cook)
            anim.SetTrigger("Cake Trigger");
        else 
            Destroy();
    }

    public void Cook(bool cake)
    {
        cook = cake;
    }

    public void Destroy()
    {
        if (GetComponent<Defenders>())
        {
            FindObjectOfType<DefenderSpawner>().DestroyDef(gameObject);   
        }
            
        Destroy(gameObject);
    }
}
