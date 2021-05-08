using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // plane
    GameObject plane;
    public float WaveDelay = 3;
    float currentWaveDelay = 0;
    // waveSpawner
    WaveSpawner waveSpawner;
    // Money
    PlayerData playerData;
    public int starCollected = 0;
    public int diamondCollected = 0;
    // UI
    //  GameUI < static >
    public Transform gameUI;
    //  MenuUI < static >
    public Transform menuUI;
    // ShopUI < static >  
    public Transform shopUI;
    ShopUI shopUIComponent;

    // GameOverUI < dynamic >   _WIP
    public GameObject gameOverUI;
    public GameObject RedBackGroundUI;
    // Mission Accomplished UI
    public GameObject gameFinishUi;

    public float DelayGameOver = 3;
    float currentDelayGameOver = 0;
    bool isGameOver = false;

    // Skill In Shop < dynamic > _WIP
    // wave UI
    public GameObject waveUI;
    // boss Warning
    public GameObject bossWarning;
    // BGM

    // Sound

    // Timer

    // Start is called before the first frame update
    void Start()
    {
        LoadResources();
        LoadComponent();

    }

    // Update is called once per frame
    void Update()
    {
        // Timer count
        if(WaveDelay > 0 && WaveDelay <= currentWaveDelay)
        {
            WaveDelay -= Time.deltaTime;
        }
        if(WaveDelay < 0)
        {
            WaveDelay = currentWaveDelay + 1;
            waveSpawner.InitWave();

        }

        if(isGameOver)
        {
            currentDelayGameOver += Time.deltaTime;
            if(currentDelayGameOver >= DelayGameOver)
            {
                isGameOver = false;
                currentDelayGameOver = 0;
                GameOverUIAppear();
            }
        }
 

        // Timer manipulation
    }

    
    void LoadComponent()
    {
        waveSpawner = this.gameObject.GetComponent<WaveSpawner>();
        shopUIComponent = shopUI.GetComponent<ShopUI>();
        shopUIComponent.plrdata = playerData;
    }
    void LoadResources() // Load sound and background
    {
        playerData = Resources.Load("PlayerData") as PlayerData;
        waveUI = Resources.Load("UI/wave") as GameObject;
        plane = Resources.Load("Plane") as GameObject;
    }
    [ContextMenu("GameStart")]
    public void GameStart()
    {
        // enable gameUI and disable menuUI
        gameUI.gameObject.SetActive(true);
        menuUI.gameObject.SetActive(false);

        waveSpawner.ResetTheWaveSpawner();
        Instantiate(plane);
        currentWaveDelay = WaveDelay;

        Debug.Log("Enemy Alive After Game Start : " + waveSpawner.EnemyAlive);

    }
    
    void Clear()
    {
        
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if(obj != null)
            {
                Destroy(obj);
            }
  
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            Destroy(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
        {
            Destroy(obj);
        }
        gameOverUI.gameObject.SetActive(false);
        gameFinishUi.gameObject.SetActive(false);
        starCollected = 0;
        diamondCollected = 0;
        RedBackGroundUI.gameObject.SetActive(false);
        
    }
    public void CloseShop()
    {
        shopUI.gameObject.SetActive(false);
    }
    public void OpenShop()
    {
        shopUI.gameObject.SetActive(true);
        shopUIComponent.Validation();
    }
    public void GameOver()
    {
        isGameOver = true;
        RedBackGroundUI.gameObject.SetActive(true);
        waveSpawner.ResetTheWaveSpawner();


        Debug.Log("Enemy Alive  when game over:" + waveSpawner.EnemyAlive);
    }
    public void GameFinished()
    {
        FinishUI fScript = gameFinishUi.gameObject.GetComponent<FinishUI>();
        gameFinishUi.gameObject.SetActive(true);
        fScript.Validation(starCollected, diamondCollected);
        playerData.AddDiamond(diamondCollected);
        playerData.AddStar(starCollected);
    }
    public void GameOverUIAppear()
    {
        gameOverUI.gameObject.SetActive(true);
    }

    public void Restart()
    {
        Clear();
        MainMenu();
        GameStart();

    }
    public void MainMenu()
    {
        Clear();
        
        gameUI.gameObject.SetActive(false);
        menuUI.gameObject.SetActive(true);
    }

    public void StartGeneratingWaves()
    {

    }

    public void WaveStart()
    {
        
    }

    public void WaveNotification(string noti)
    {
        Instantiate(waveUI, gameUI).GetComponent<WaveNotification>().setNoti(noti);
    }

}
