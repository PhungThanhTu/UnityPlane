using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffEffect
{
    attack_speed,
    num_bullet,
    bullet_up,
    combo_up
}


public class ItemEffect : MonoBehaviour
{
    GunPoint buffedObject;

    GameObject collectEffect;

    public BuffEffect effect;

    // Start is called before the first frame update
    private void Start()
    {
        this.gameObject.AddComponent<Rigidbody2D>().gravityScale = 0;
        this.gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
    }
    private void Update()
    {
        gameObject.transform.position += new Vector3(0, -0.5f, 0)*Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "CollectItemHitBox")
        {
            buffedObject = collision.transform.parent.gameObject.GetComponentInChildren<GunPoint>();

            switch(effect)
            {
                case BuffEffect.attack_speed:
                    {   
                        if(buffedObject.fireDelay > 0.25f)
                            buffedObject.fireDelay *= 0.85f;
                        break;
                    }
                case BuffEffect.bullet_up:
                    {
                        buffedObject.BulletUp();
                        break;
                    }
                case BuffEffect.num_bullet:
                    {   
                        if(buffedObject.comboBulletCount < 6)
                            buffedObject.countBulletPerShot++;
                        break;
                    }
                case BuffEffect.combo_up:
                    {
                        if(buffedObject.comboBulletCount <4)
                            buffedObject.comboBulletCount++;
                        break;
                    }
            }
            Destroy(gameObject);
        }
    }

}
