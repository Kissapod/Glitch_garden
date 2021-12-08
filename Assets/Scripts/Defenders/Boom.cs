using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        Health health = collision.gameObject.GetComponent<Health>();
        if (attacker && health) //если у объекта с которым столкнулся снаряд есть скрипты Аттакер и Здоровье
        {
            health.DealDamage(damage); //передаем значение урона в скрипт здоровья цели
        }
    }

   public void Destroy()
    {
        Destroy(gameObject);
    }
}
