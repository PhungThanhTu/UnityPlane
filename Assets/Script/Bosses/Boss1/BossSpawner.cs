using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject warning;
    // Start is called before the first frame update
    void Start()
    {
        Transform gameUi = GameObject.Find("gameUI").transform;
        Instantiate(warning, gameUi);
        Destroy(gameObject);
        
    }

    // Update is called once per frame

}
