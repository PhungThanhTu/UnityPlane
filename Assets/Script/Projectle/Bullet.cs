using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public int Damage = 8;
    public float FlyingSpeed = 2;
    public float DeathTime = 2;
    public GameObject prefabExplosion;
    public float spacing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, 1, 0) * FlyingSpeed*Time.deltaTime;
       
        if(DeathTime <= 0)
        {
            Explode();
        }
        Death();
    }

    void Death()
    {
        DeathTime -= Time.deltaTime;
        if (DeathTime <= 0)
        {
            Explode();
        }
    }
    void Explode()
    {
        Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
            Explode();
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
            Explode();
        }
    }
}
    
