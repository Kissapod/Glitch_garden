using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : Shooter
{
    public float damage;
    public List<GameObject> currentTargets;

    private float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); //находим оба компонента, чтобы присвоить их переменным
        SetMyLaneSpawner();
    }

    public override void Update()
    {
        if (IsAttakerAheadInLane() || BossAheadInLane() || transform.position.x > 9.5) //если вернулось значение ИСТИНА, то
        {
            animator.SetBool("isAttack", true); //переключаемся в режим атаки
            transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isAttack", false); //иначе переключаемся в режим ожидания
            transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
        }
        if (currentTargets.Count > 0)
            currentTargets.RemoveAll(x => x == null);
        for (int i = 0; i < currentTargets.Count; i++) // проверяем не смяты ли цели
        {
            if (currentTargets[i].GetComponent<Animator>().GetBool("Cake Trigger"))
                currentTargets.Remove(currentTargets[i]);
        }
        if (currentTargets.Count <= 0) // чистим массив от уничтоженных объектов
        {
            animator.SetBool("Attack", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject; // создаем игровой объект и присваиваем ему игровой объект, с которым столкнулась ящерица
        if (!obj.GetComponent<Attacker>()) //если у объекта нет скрипта защитника, то мы выходим из метода
            return;
        else
        {
            if (obj.GetComponent<JumpAttacker>())
                return;
            if (!obj.GetComponent<Health>() || obj.GetComponent<Health>().health < 100)
                return;
            currentTargets.Add(obj);
            animator.SetBool("Attack", true);
        }
    }
    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }
    public void StrikeCurrentTarget()
    {
        if (currentTargets.Count > 0) //если у нас есть текущая цель, мы находим у цели компонент здоровья и передаем значение этого компонента в новую переменную health
        {
            foreach (GameObject obj in currentTargets)
            {
                Health health = obj.GetComponent<Health>();
                if (health)
                    health.DealDamage(damage / currentTargets.Count);
            }
        }
    }

    public override void Fire()
    {

    }
}
