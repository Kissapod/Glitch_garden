using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject boss;
    // Start is called before the first frame update

    public void BossBorn()
    {
        Instantiate(boss, transform.position, Quaternion.identity, transform);
        foreach (Shooter shooter in FindObjectsOfType<Shooter>())
            shooter.bossLaneSpawner = GetComponent<BossSpawner>();
    }
}
