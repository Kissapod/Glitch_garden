using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))] //добавляем обязательный компонент для нашего класса ящерицы
public class Lizard : MonoBehaviour
{
    private Animator anim; //создаем две приватных переменных, которые будут описывать нашу анимацию и атаку
    private Attacker attacker;
    [HideInInspector] public bool teleportActivity;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //находим оба компонента, чтобы присвоить их переменным
        attacker = GetComponent<Attacker>();
        teleportActivity = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject; // создаем игровой объект и присваиваем ему игровой объект, с которым столкнулась лиса
        if (!obj.GetComponent<Defenders>() || obj.GetComponent<Shovel>()) //если у объекта нет скрипта защитника, то мы выходим из метода
        {
            return;
        }
        if (teleportActivity)
        {
            anim.SetTrigger("Teleport Trigger");
            teleportActivity = false;
        }
        else
        {
            if (obj.GetComponent<Cook>())
                anim.SetTrigger("Cake Trigger");
            anim.SetBool("isAttack", true);
            attacker.Attack(obj);
        }
    }
}
