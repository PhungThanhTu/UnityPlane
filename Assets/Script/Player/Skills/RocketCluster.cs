using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCluster : MonoBehaviour
{

    public int RocketCount = 30;
    public Transform _owner;
    public float interval = 0.25f;
    float currentInterval = 0;
    GameObject Instantiator;
    public Rocket componentPrefabRocket;
    // Start is called before the first frame update
    void Start()
    {
        _owner = GameObject.FindGameObjectWithTag("Player").transform;
        this.transform.parent = _owner;
        Instantiator = GameObject.Find("SkillCharge");
        Instantiator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        if(RocketCount == 0)
        {
            Instantiator.SetActive(true);
            Destroy(this.gameObject);
        }
        currentInterval += Time.deltaTime;
        if(currentInterval >= interval)
        {
            currentInterval = 0;

            RocketCount--;
            componentPrefabRocket.direction = new Vector3(Random.Range(-1f,1f),1,0).normalized;
            Instantiate(componentPrefabRocket, transform.position, Quaternion.identity);
        }
    }
}
