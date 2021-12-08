using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pugalo : Shooter
{
    public GameObject projectile2, projectile3;
    public List<Spawner> myLaneSpawners;

    private Spawner upSpawner;
    private Spawner downSpawner;
    public void Start()
    {
        animator = FindObjectOfType<Animator>(); //находим аниматор у нашего защитника
        projectileParent = GameObject.Find("Projectiles"); //пытаемся найти объект РОДИТЕЛЬ
        if (!projectileParent) //если РОДИТЕЛЯ не существует, то
        {
            projectileParent = new GameObject("Projectiles"); //создаем новый объект РОДИТЕЛЯ
        }
        SetMyLaneSpawner(); //запускаем метод для поиска спаунов врагов
    }

    public override void SetMyLaneSpawner()
    {
        bossLaneSpawner = FindObjectOfType<BossSpawner>();
        Spawner[] spawnerArray = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawnerArray)
        {
            if (spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawners.Add(spawner);
            }
        }
        foreach (Spawner spawner in spawnerArray)
        {
            if (spawner.transform.position.y == myLaneSpawners[0].transform.position.y - 1)
            {
                myLaneSpawners.Add(spawner);
                upSpawner = spawner;
            }
            if (spawner.transform.position.y == myLaneSpawners[0].transform.position.y + 1)
            {
                myLaneSpawners.Add(spawner);
                downSpawner = spawner;
            }
        }
    }

    public override bool IsAttakerAheadInLane()
    {
        int count = 0;
        foreach (Spawner spawner in myLaneSpawners)    //проверяем есть ли у точки спауна дочерние объекты
        {
            if (spawner.transform.childCount <= 0)
                count++;
        }
        if (count == myLaneSpawners.Count)
        {
            Debug.Log("Враг не найден");
            return false;
        }
        foreach (Spawner spawner in myLaneSpawners) //для каждого атакующего из точки спауна проверяем условие
        {
            foreach (Transform attaker in spawner.transform)
            {
                if (attaker.transform.position.x > transform.position.x) //если позиция атакующего по Х больше чем наша позиция, то возвращаем ИСТИНУ
                {
                    Debug.Log("Враг найден");
                    return true;
                }
            }         
        }
        return false; //в других случаях всегда возвращается ЛОЖЬ
    }

    public override void Fire()
    {
        base.Fire();
        if (downSpawner && downSpawner.transform.childCount > 0)
            Instantiate(projectile2, gun.transform.position, Quaternion.identity, projectileParent.transform);
        if (upSpawner && upSpawner.transform.childCount > 0)
            Instantiate(projectile3, gun.transform.position, Quaternion.identity, projectileParent.transform);
    }  
}
