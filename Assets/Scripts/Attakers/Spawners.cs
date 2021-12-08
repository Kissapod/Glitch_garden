using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    public float spawnerInvokeTime = 20;
    public float spawnRate = 1;

    public GameObject[] attakerPrefabArray; // создаем публичный массив куда закидываем префабы атакующих

    private Transform[] spawners;
    private float difficulty;
    private void Start()
    {
        difficulty = PlayerPrefsManager.GetDifficulty();
        if (difficulty == 1f)
        {
            spawnRate *= 0.7f;
        }
        else if (difficulty == 2f)
        {
            spawnRate *= 1f;
        }
        else if (difficulty == 3f)
        {
            spawnRate *= 1.3f;
        }
        spawners = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        if (spawnerInvokeTime > Time.timeSinceLevelLoad)
            return;
        foreach (GameObject thisAttaker in attakerPrefabArray) //теперь для каждого этого аттакера из массива атакующих применяем следующее условие
        {
            if (isTimeToSpawn(thisAttaker) && SpawnersClear()) //если настало время для появления этого атакующего то
            {
                bool spawnAttacker = false;
                do
                {
                    int rand = Random.Range(1, 6);
                    if (spawners[rand].GetComponent<Spawner>().spawnerClear)
                    {

                        Spawn(thisAttaker, spawners[rand]);
                        spawnAttacker = true;
                    } else
                    continue;
                } while (!spawnAttacker);
            }
        }
    }

    void Spawn(GameObject myGameObject, Transform spawner)
    {
        GameObject myAttaker = Instantiate(myGameObject, spawner); //создаем игровой объект с родителем Спаунер
        myAttaker.transform.position = spawner.position; // и назначаем ему координаты родителя
    }

    bool isTimeToSpawn(GameObject attakerGameObject)
    {
        Attacker attaker = attakerGameObject.GetComponent<Attacker>(); //создаем переменную аттакер типа игровой объект и ищем у нашего атакующего скрипт аттакер, который присваиваем данной переменной
        float meanSpawnDelay = attaker.seenEverySeconds / spawnRate; //создаем дробную переменную "Промежуток между появлениями", и присваиваем ей значение переменной "Среднее кол-во секунд" из скрипта Аттакер
        float spawnPerSecond = 1 / meanSpawnDelay; //создаем дробную переменную "Появление в секунду" и присваиваем ей значение единицы деленной на "Промежуток между появлениями"

        if (Time.deltaTime > meanSpawnDelay) // если "Частота кадров" больше промежутка между появлениями, то 
        {
            Debug.LogWarning("Частота появления ограничена частотой кадров"); //выводим сообщение об ошибке
        }
        if (DefenderSpawner.powerDef >= 10)
        {
            Debug.Log("Много защитников");
            float threshold = (spawnPerSecond * Time.deltaTime) * (DefenderSpawner.powerDef / 10); //создаем дробную переменную "Тресхолд" и присваиваем ей значение "Появление в секунду" умноженное на количество кадров в секунду деленное на 5 (так как у нас 5 рядов)
            return (Random.value < threshold);
        }
        else if (Time.timeSinceLevelLoad > 60)
        {
            Debug.Log("Прошло больше минуты");
            float threshold = (spawnPerSecond * Time.deltaTime) * (Time.timeSinceLevelLoad / 60); //создаем дробную переменную "Тресхолд" и присваиваем ей значение "Появление в секунду" умноженное на количество кадров в секунду деленное на 5 (так как у нас 5 рядов)
            return (Random.value < threshold);
        }
        else
        {
            Debug.Log("Стандартное появление");
            float threshold = spawnPerSecond * Time.deltaTime; //создаем дробную переменную "Тресхолд" и присваиваем ей значение "Появление в секунду" умноженное на количество кадров в секунду деленное на 5 (так как у нас 5 рядов)
            return (Random.value < threshold);
        }
    }

    private bool SpawnersClear()
    {
        for (int i = 1; i < 6; i++)
        {
            if (spawners[i].GetComponent<Spawner>().spawnerClear)
                return true;
            break;
        }
        return false;
    }
}
