using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction = Vector3.up;   
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
        this.transform.position += direction * FlyingSpeed*Time.deltaTime;


        float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        this.transform.rotation = Quaternion.Euler(0, 0, Angle);

        if (DeathTime <= 0)
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
    
