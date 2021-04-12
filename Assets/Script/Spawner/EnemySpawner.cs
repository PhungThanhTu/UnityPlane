using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{

    public GameObject[] prefabEnemies;
    public int numType = 0;
    public GameObject[] prefabBosses;
    public int bossTypeCount = 0;
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
        
    }


    public void SpawnEnemy(int id)
    {

    }

    void LoadResources()
    {
        while(true)
        {
            prefabEnemies[numType] = Resources.Load("Enemies/Enemy" + numType.ToString()) as GameObject;
            if(prefabEnemies[numType] == null)
            {
                numType++;
                break;
            }
            else
            {
                numType++;
            }
        }
        while (true)
        {
            prefabBosses[bossTypeCount] = Resources.Load("Bosses/Boss" + bossTypeCount.ToString()) as GameObject;
            if (prefabBosses[bossTypeCount] == null)
            {
                bossTypeCount++;
                break;
            }
            else
            {
                bossTypeCount++;
            }
        }

    }
}
