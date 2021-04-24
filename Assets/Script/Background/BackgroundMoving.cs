using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    public float flySpeed = 0.02f;
    float timeDelay;
    
    // Start is called before the first frame update
    void Start()
    {
        timeDelay = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, -1, 0) * flySpeed*Time.deltaTime;

        if(this.transform.position.y <= -10.24f)
        {
            float deltaY = transform.position.y + 10.24f;
            this.transform.position = new Vector3(0, 10.24f+deltaY,0);
        }
    }
}
