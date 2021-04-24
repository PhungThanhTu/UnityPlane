using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningController : MonoBehaviour
{
     WaveSpawner spawner;
    void Start()
    {
        spawner = GameObject.Find("TheGameManager").GetComponent<WaveSpawner>();
    }

    private void OnDestroy()
    {
        spawner.EnemyAlive--;
        Debug.Log("Enemy Alive after object destroy : " + spawner.EnemyAlive);
    }
}