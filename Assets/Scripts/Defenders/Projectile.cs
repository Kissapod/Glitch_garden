using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, damage;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // создаем переменную аттакер, которой присваиваем компонент скрипт АТТАКЕР
        Attacker attacker = collision.gameObject.GetComponent<Attacker>(); 
        Health health = collision.gameObject.GetComponent<Health>(); // создаем переменную здоровье, которой присваиваем компонент скрипт ЗДОРОВЬЕ

        if (attacker && health) //если у объекта с которым столкнулся снаряд есть скрипты Аттакер и Здоровье
        {
            Repel(attacker);
            health.DealDamage(damage); //передаем значение урона в скрипт здоровья цели
            Destroy(gameObject); //уничтожаем наш снаряд
        }
    }
    public virtual void Repel(Attacker attacker)
    {
         
    }

}
