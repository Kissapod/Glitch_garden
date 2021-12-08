using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject gun, projectile;

    [HideInInspector] public GameObject projectileParent;
    [HideInInspector] public Animator animator;
    [HideInInspector] public Spawner myLaneSpawner;
    [HideInInspector] public BossSpawner bossLaneSpawner;

    void Start()
    {
        animator = GetComponent<Animator>(); //находим аниматор у нашего защитника
        projectileParent = GameObject.Find("Projectiles"); //пытаемся найти объект РОДИТЕЛЬ
        if (!projectileParent) //если РОДИТЕЛЯ не существует, то
        {
            projectileParent = new GameObject("Projectiles"); //создаем новый объект РОДИТЕЛЯ
        }
        SetMyLaneSpawner(); //запускаем метод для поиска спаунов врагов
    }
    public virtual void Update()
    {
        if (IsAttakerAheadInLane() || BossAheadInLane()) //если вернулось значение ИСТИНА, то
        {
            animator.SetBool("isAttack", true); //переключаемся в режим атаки
        } else
        {
            animator.SetBool("isAttack", false); //иначе переключаемся в режим ожидания
        }
    }

    //находим наши спаунеры на линии
    public virtual void SetMyLaneSpawner()
    {
        bossLaneSpawner = FindObjectOfType<BossSpawner>();
        Spawner[] spawnerArray = FindObjectsOfType<Spawner>(); //создаем массив, в который заносим все точки спауна врагов
        foreach (Spawner spawner in spawnerArray) //теперь для каждой точки мы проверяем условие
        {
            if (spawner.transform.position.y == transform.position.y) //если позиция по "у" точки совпадает с нашей позицией, то
            {
                myLaneSpawner = spawner; //присваиваем переменной "СпаунНаМоейЛинии" нашу точку спауна
                return; //выходим из метода
            }
        }
    }

    public virtual bool IsAttakerAheadInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)    //проверяем есть ли у точки спауна дочерние объекты
        {
            return false; //если их нет, то возвращаем значение ЛОЖЬ
        }
        foreach (Transform attaker in myLaneSpawner.transform) //для каждого атакующего из точки спауна проверяем условие
        {
            if (attaker.transform.position.x > transform.position.x) //если позиция атакующего по Х больше чем наша позиция, то возвращаем ИСТИНУ
            {
                return true;
            }
        }
        return false; //в других случаях всегда возвращается ЛОЖЬ
    }

    public bool BossAheadInLane()
    {
        if (GameTimer.bossInLevel)
        {
            if (bossLaneSpawner.transform.childCount <= 0)    //проверяем есть ли у точки спауна дочерние объекты
            {
                return false; //если их нет, то возвращаем значение ЛОЖЬ
            }
            foreach (Transform attaker in bossLaneSpawner.transform) //для каждого атакующего из точки спауна проверяем условие
            {
                if (attaker.transform.position.x > transform.position.x) //если позиция атакующего по Х больше чем наша позиция, то возвращаем ИСТИНУ
                {
                    return true;
                }
            }
        }
        return false; //в других случаях всегда возвращается ЛОЖЬ
    }

    public virtual void Fire()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity, projectileParent.transform);
    }
}
