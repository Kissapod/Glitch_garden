using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{
    [Tooltip("Среднее количество секунд между появлением врагов")]
    public float seenEverySeconds;
    public float repelRange;
    public float currentSpeed;
    public bool isAttaker;
    public bool isBoss;
    private GameObject currentTarget; //создаем переменную объект, которая будет нашей текущей целью
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget && isAttaker && animator.GetBool("isAttack") && !isBoss)
        {
                animator.SetBool("isAttack", false);
                GetComponent<Health>().Cook(false);
        }
        if (isBoss)
        {
            if (GetComponent<JabbaWomen>().currentTargets.Count == 0)
                animator.SetBool("isAttack", false);
        }
    }


    IEnumerator moveYToZero()
    {
        Vector3 startPos = transform.position; // запоминаем начальную позицию
        Vector3 endPos = new Vector3(startPos.x+repelRange, startPos.y, startPos.z); // запоминаем нужную конечную позицию
        float speed = 0.1f; //  скорость прогресса (от начальной до конечной позиции)
        if (repelRange >= 1)
            speed /= repelRange*2;
        float progress = 0;
        while (true)
        {
            progress += speed;
            transform.position = Vector3.Lerp(startPos, endPos, progress);
            if (progress > 1) yield break; // выход из корутины, если находимся в конечной позиции
            yield return null; // если выхода из корутины не произошло, то продолжаем выполнять цикл while в следующем кадре
        }
    }

    public void SetSpeed (float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget (float damage)
    {
        if (currentTarget) //если у нас есть текущая цель, мы находим у цели компонент здоровья и передаем значение этого компонента в новую переменную health
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }
    public void Attack (GameObject obj)
    {
        currentTarget = obj; //присваимаем текущей цели объект, с которым столкнулся атакующий
    }

    public void StartCarutine()
    {
        if (!isBoss)
        {
            StartCoroutine("moveYToZero");
            if (animator.GetBool("isAttack") && isAttaker)
                animator.SetBool("isAttack", false);
        }
    }
}
