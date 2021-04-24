using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{

    int Phases = 0;
    public GameObject healthbar;

    public BulletPattern gunPoint;
    public Enemy enemy;
    public Health health;
    GameObject healthUI;
    public float moveTime = 5;

    //0 appear phases
    //1 around phases
    //2 attack phases
    // Start is called before the first frame update
    void Start()
    {
        Transform gameUI = GameObject.Find("gameUI").transform;
        healthUI = Instantiate(healthbar, gameUI);
        healthUI.GetComponent<BossHealthbar>().health = this.GetComponent<Health>();

        gunPoint.enabled = false;
        health.Invincible = true;
        enemy.speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        moveTime -= Time.deltaTime;
        if(moveTime <= 0)
        {

            gunPoint.enabled = true;
            health.Invincible = false;
            enemy.speed = 0;
        }
    }

    private void OnDestroy()
    {
        Destroy(healthUI.gameObject);
    }

    void Phase0()
    {

    }

}
