using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToPlayer : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject playe = GameObject.FindGameObjectWithTag("Player");
        if(playe != null)
        {
            Vector3 dir = (playe.transform.position - this.transform.position).normalized;
            this.transform.position += dir * speed * Time.deltaTime;
            
        }
    }
}
