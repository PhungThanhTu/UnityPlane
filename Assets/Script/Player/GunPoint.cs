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
    public bool autoShoot = false;

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
       
        if(Input.GetMouseButtonDown(1))
        {
            autoShoot = !autoShoot;
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
                Vector3 spacingVector;
                if(middleBull == 0)
                {   
                    int Spacing = 2*i + 1;
                    spacingVector = new Vector3(Spacing * 0.1f, 0, 0);
                }
                else
                {
                    int Spacing = 2 * (i+1);
                    spacingVector = new Vector3(Spacing * 0.1f, 0, 0);
                }
                
                    Instantiate(prefabBullet, transform.position + spacingVector , Quaternion.identity);
                    Instantiate(prefabBullet, transform.position - spacingVector , Quaternion.identity);
                
               
            }
            currentComboDelay = 0;
        }
        if(currentComboCount == 0)
        {
            isShooting = false;
        }
    }
}
