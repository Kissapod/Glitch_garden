using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JabbaWomen : MonoBehaviour
{
    private Animator anim; //создаем две приватных переменных, которые будут описывать нашу анимацию и атаку
    public List<GameObject> currentTargets;
    public GameObject projectile;
    public GameObject[] spawners;
    public float fireTimer = 10f;
    private bool fireChecked;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //находим оба компонента, чтобы присвоить их переменным
        fireChecked = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (currentTargets.Count > 0)
        currentTargets.RemoveAll(x => x == null);
        if (transform.position.x < 9.5f && !fireChecked && DefenderSpawner.powerDef > 0)
        {
            Fire();
        }
        if (timer >= fireTimer)
        {
            fireChecked = false;
            timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject; // создаем игровой объект и присваиваем ему игровой объект, с которым столкнулась ящерица
        if (!obj.GetComponent<Defenders>() || obj.GetComponent<Shovel>()) //если у объекта нет скрипта защитника, то мы выходим из метода
        {
            return;
        }
        else
        {
            currentTargets.Add(obj);
            anim.SetBool("isAttack", true); // так как наш атакующий атакует всех защитников , то при столкновении с защитником сразу включаем ивент атаки
        }
    }

    public void StrikeCurrentTargets(float damage)
    {
        if (currentTargets.Count > 0) //если у нас есть текущая цель, мы находим у цели компонент здоровья и передаем значение этого компонента в новую переменную health
        {
            foreach (GameObject obj in currentTargets)
            {
                Health healthTarget = obj.GetComponent<Health>();
                if (healthTarget)
                {
                    healthTarget.DealDamage(damage/currentTargets.Count);
                }
            }
        }
    }

    private void Fire()
    {
        fireChecked = true;
        anim.SetTrigger("Fire Trigger");
    }

    public void ProjectileCreate()
    {
        foreach (GameObject spawner in spawners)
            Instantiate(projectile, spawner.transform);
    }
}
