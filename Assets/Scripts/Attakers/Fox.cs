using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))] //добавляем обязательный компонент для нашего класса лисы
public class Fox : MonoBehaviour
{
    private Animator anim; //создаем две приватных переменных, которые будут описывать нашу анимацию и атаку
    private Attacker attacker;
    public bool jumpActivity;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //находим оба компонента, чтобы присвоить их переменным
        attacker = GetComponent<Attacker>();
        jumpActivity = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject; // создаем игровой объект и присваиваем ему игровой объект, с которым столкнулась лиса
        if (!obj.GetComponent<Defenders>() || obj.GetComponent<Shovel>()) //если у объекта нет скрипта защитника, то мы выходим из метода
        {
            return;
        }
        if (jumpActivity)
        {
            anim.SetTrigger("Jump Trigger");
            jumpActivity = false;
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
