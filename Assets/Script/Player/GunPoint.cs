using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPoint : MonoBehaviour
{
    // thong so co ban
    public int countBulletPerShot = 1;
    public float comboBulletCount = 6;
    public float fireDelay = 1;
    public GameObject prefabBullet;

    // tat tu dong ban
    public bool autoShoot = true;

    float currentDelay = 0;
    float currentComboDelay = 0;
    float currentComboCount = 0;
    bool isShooting = false;
    // Start is called before the first frame update
    void Start()
    {
        currentComboCount = comboBulletCount;
        currentComboDelay = fireDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentDelay <= fireDelay)
        {
            currentDelay += Time.deltaTime;
        }
       
        
        if(autoShoot || Input.GetMouseButtonDown(0))
        {
            if(currentDelay >= fireDelay)
            {
                isShooting = true;
                currentComboCount = comboBulletCount;
                currentDelay = 0;
            }
           
        }
        if(isShooting == true)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        currentComboDelay += Time.deltaTime;
        if(currentComboDelay >= 0.1f && currentComboCount != 0)
        {
            currentComboCount--;
            int middleBull = countBulletPerShot % 2;
            int sideBull = countBulletPerShot / 2;

            for(int i = 1; i <= middleBull; i++)
            {
                Instantiate(prefabBullet, transform.position, Quaternion.identity);
            }
            
            
            for(int i = 0; i < sideBull; i++)
            {
                Vector3 bulletDir;
                Vector3 reflectBulletDir;
                float Spacing;
                if(middleBull == 0)
                {
                   bulletDir = new Vector3(0.025f*(2*i+1),1, 0).normalized;
                   reflectBulletDir = new Vector3(-0.025f*(2*i + 1), 1, 0).normalized;
                    Spacing = 0.05f*(2 * i + 1);
                }
                else
                {
                    bulletDir = new Vector3(0.05f*(i+1), 1, 0).normalized;
                    reflectBulletDir = new Vector3(-0.05f*(i+1), 1, 0).normalized;
                    Spacing = 0.1f*(i + 1);
                }

                Instantiate(prefabBullet, transform.position + new Vector3(Spacing,0,0), Quaternion.identity).GetComponent<Bullet>().direction = bulletDir;
                Instantiate(prefabBullet, transform.position + new Vector3(-Spacing,0,0), Quaternion.identity).GetComponent<Bullet>().direction = reflectBulletDir;
            }


            currentComboDelay = 0;
            if (currentComboCount == 0)
            {
                isShooting = false;
            }

        }
       
    }
        
}
