using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int damage = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHitBox hitbox = collision.GetComponent<PlayerHitBox>();
        if(hitbox != null)
        {
            hitbox.TakeDamageAndBuffering(damage);
        }
       
    }
}
        
