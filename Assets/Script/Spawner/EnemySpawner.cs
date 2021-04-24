using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{

    public List<GameObject> prefabEnemies;
    int numType = 0;

    public float spawnTime = 0.5f;
    float currentSpawnTime = 0;

    public int currentId = 0;
    public int count = 0;

    public Transform spawnPlace;

    // Spawn Location

    // Spawn by waves at 0.5i i mean spawnslot -5 <= i <= 5

    // Start is called before the first frame update
    void Start()
    {

        LoadResources();
    }

    // Update is called once per frame
    void Update()
    {
        // spawn time count 
        if(count > 0)
        {
            currentSpawnTime += Time.deltaTime;

            if (currentSpawnTime >= spawnTime)
            {
                currentSpawnTime = 0;
                SpawnEnemy(currentId);
                count--;
            }

        }

      
    }


    public void SpawnEnemy(int id)
    {
        if(prefabEnemies[id] != null)
        {
            Instantiate(prefabEnemies[id], spawnPlace.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Enemy type not found");
        }
        
    }

    void LoadResources()
    {
        while(true)
        {
            GameObject loadEnemy = Resources.Load("Enemies/Enemy" + numType.ToString()) as GameObject;
            if(loadEnemy == null)
            {
                
                break;
            }
            else
            {
                prefabEnemies.Add(loadEnemy);
                numType++;
            }
        }
       

    }
}
