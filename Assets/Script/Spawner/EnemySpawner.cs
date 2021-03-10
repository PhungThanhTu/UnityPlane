using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{

    public GameObject prefabEnemy;
    float spawnTime;

    // Spawn Location

    // Spawn by waves at 0.5i i mean spawnslot -5 <= i <= 5

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(3f, 10f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTime <= 0)
        {
            spawnTime = Random.Range(3f, 10f);

            Instantiate(prefabEnemy, transform.position, Quaternion.identity);
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
    }
}
