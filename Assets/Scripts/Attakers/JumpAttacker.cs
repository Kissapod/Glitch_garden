using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))] //добавляем обязательный компонент для нашего класса лисы
public class JumpAttacker : MonoBehaviour
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
        }
        else
        {
            if (obj.GetComponent<Cook>())
            {
                if (GetComponent<Health>().health > obj.GetComponent<Cook>().damage)
                {
                    obj.GetComponent<Cook>().currentTargets.Add(gameObject);
                    obj.GetComponent<Animator>().SetBool("Attack", true);
                    GetComponent<Health>().Cook(true);
                }
                else
                    anim.SetTrigger("Cake Trigger");
            }
            anim.SetTrigger("isAttack"); 
            attacker.Attack(obj); //переносим этот объект в метод аттак в скрипте аттакерс
        }
    }

    void JumpActive(int jump)
    {
        if (jump == 0)
            jumpActivity = false;
    }
}
