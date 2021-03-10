using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDmgAndExplode : MonoBehaviour
{
    public int Damage = 8;
    public float DeathTime = 2;
    public GameObject prefabExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
            Explode();
        }
    }
}
