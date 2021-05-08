using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    Game gameManager;

    public WaveInfo waveDataObject;
    public EnemySpawner spawner;

    // UI for Spawn New Waves
    
    // UI for finish

    // enemy alive
    public int EnemyAlive = 0;


    // bool for Start
    public bool isSTART = false;

    public bool waveStarted = true;

    public float waveInterval = 3;
    public float currentWaveInterval = -1;

    // count wave
    public int waveIndex = -1;

    int swarnIndex = 0;
    // Finish Delay Counter
    bool isFinish = false;
    public float FinishTime = 3f;
    float currentFinishTime = 0;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("TheGameManager").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        // IN UPDATE 
        if(isSTART)
        {
            if(currentWaveInterval < 0)
                StartSpawning();
              
           
            
            if (currentWaveInterval >= 0)
            {
                currentWaveInterval += Time.deltaTime;

                if (currentWaveInterval >= waveInterval)
                {
                    currentWaveInterval = -1;
                    // spawn the whole wave
                    
                    GenerateNewWave();

                }
            }
            if(waveIndex >= 0)
            {
                
                SpawnSingleSwarn();
            }
 


        }
       
        // if finish
        if(isFinish)
        {
            currentFinishTime += Time.deltaTime;
            if(currentFinishTime >= FinishTime)
            {
                // do the stuff after finish delay
                AfterFinishDelay();
                // reset the counter
                isFinish = false;
                currentFinishTime = 0;
            }
        }

        
    }

    void GenerateNewWave()
    {
        Debug.Log("Generating new Wave");
        waveIndex++;

        if(waveIndex == waveDataObject.data.data.waves.Length)
        {
            ResetTheWaveSpawner();
            isFinish = true;
        }
        else
        {
            foreach (SwarnInfo singleSwarn in waveDataObject.data.data.waves[waveIndex].swarns)
            {
                EnemyAlive += singleSwarn.count;
            }
            swarnIndex = 0;
        }

        
      
    }

    void SpawnSingleSwarn()
    {
        if(swarnIndex < waveDataObject.data.data.waves[waveIndex].swarns.Length && spawner.count == 0 && EnemyAlive > 0)
        {
            SwarnInfo singleswarn = waveDataObject.data.data.waves[waveIndex].swarns[swarnIndex];

            spawner.currentId = singleswarn.EnemyId;
            spawner.count = singleswarn.count;
            swarnIndex++;
        }
        if(EnemyAlive == 0)
        {
            waveStarted = true;
        }

    }

    [ContextMenu("Init Wave")]
    public void InitWave()
    {
        isSTART = true;
       
    }


    public void SetEnemyAliveToZero()
    {
        EnemyAlive = 0;
    }

    public void ResetTheWaveSpawner()
    {
        isSTART = false;
        waveStarted = true;
        isFinish = false;
        swarnIndex = 0;
        waveIndex = -1;
        
        
    }

    public void StartSpawning()
    {
        if(EnemyAlive == 0)
        {
            if(waveIndex < waveDataObject.data.data.waves.Length-1)
            {
                gameManager.WaveNotification("Wave " + (int)(waveIndex + 2) + " begin");
                Debug.Log(waveIndex);
                Debug.Log(waveDataObject.data.data.waves.Length);
            }
        else
            {
                Finish();
            }
            currentWaveInterval = 0;
        }
    }


    public void Finish()
    {
        // start finish delay


        
        if(!isFinish)
        {
            CoolAppear planecmp = GameObject.FindGameObjectWithTag("Player").GetComponent<CoolAppear>();

            if (planecmp != null)
            {
                planecmp.enabled = true;
                planecmp.Finish();
            }
        }
        // destroy all bullet in the area
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            obj.gameObject.GetComponent<Bullet>().Explode();
        }

        isFinish = true;
    }

    public void AfterFinishDelay()
    {
        // Finish
        Debug.Log("Finish");
        gameManager.GameFinished();
    }


}
