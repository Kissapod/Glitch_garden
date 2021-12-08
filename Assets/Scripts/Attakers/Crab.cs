using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Crab : MonoBehaviour
{
    private Animator anim; //создаем две приватных переменных, которые будут описывать нашу анимацию и атаку
    private Attacker attacker;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //находим оба компонента, чтобы присвоить их переменным
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject; // создаем игровой объект и присваиваем ему игровой объект, с которым столкнулся атакующий
        if (!obj.GetComponent<Defenders>() || obj.GetComponent<Shovel>())  //если у объекта нет скрипта защитника, то мы выходим из метода
            return;
        else
        {
            if (obj.GetComponent<Cook>())
            {
                if (GetComponent<Health>().health > obj.GetComponent<Cook>().damage)
                    GetComponent<Health>().Cook(true);
                else
                    anim.SetTrigger("Cake Trigger");
            }
            anim.SetTrigger("isAttack"); // так как наша Ящерица атакует всех защитников , то при столкновении с защитником сразу включаем ивент атаки
            attacker.Attack(obj); //переносим этот объект в метод аттак в скрипте аттакерс
        }
    }
}