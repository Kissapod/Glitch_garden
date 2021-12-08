using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom1 : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Defenders defender = collision.gameObject.GetComponent<Defenders>();
        Health health = collision.gameObject.GetComponent<Health>();
        if (defender && health) //если у объекта с которым столкнулся снаряд есть скрипты защитник и здоровье
        {
            Debug.Log("Нанесение урона");
            health.DealDamage(damage); //передаем значение урона в скрипт здоровья цели
        }
    }

   public void Destroy()
   {
        Destroy(gameObject);
   }
}
