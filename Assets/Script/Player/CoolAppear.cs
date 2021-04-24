using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolAppear : MonoBehaviour
{
    public Moving moving;
    public GunPoint gunPoint;
    public float AppearTime = 2;
    public float AppearSpeed = 0.75f;
    bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        moving.enabled = false;
        gunPoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        AppearTime -= Time.deltaTime;
        this.gameObject.transform.position += new Vector3(0, 1, 0) * AppearSpeed * Time.deltaTime;

        if(AppearTime <= 0 && !isStart)
        {
            isStart = true;
            moving.enabled = true;
            gunPoint.enabled = true;
            this.enabled = false;

        }
    }


    public void Finish()
    {

        moving.enabled = false;
        gunPoint.enabled = false;
        AppearSpeed = 6f;
    }
}
