using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -1, 0) * speed*Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth =  collision.GetComponent<PlayerHealth>();
        if(playerHealth != null)
        {
            playerHealth.TakeDamage(10);
        }
        Buffering playerBuffering = collision.GetComponent<Buffering>();
        if(playerBuffering != null)
        {
            playerBuffering.StartBuffering();
        }
    }
}
