using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Pattern
{
    Single,
    Multi,
    MultiStraight,
    Hexa,
    Octa,

}
public class BulletPattern : MonoBehaviour
{
    public Vector3 ShootDirection = new Vector3(0, -1, 0);
    public float fireDelay = 0.5f;
    float currentFireDelay = 0;

    public Pattern bulletPatterns;
    public int bulletCountForMultiFront = 1;
    public float spacingX = 0.1f;
    public float spacingY = 0;
    public float AngleSpacing = 10f;
    public Bullet bullets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentFireDelay += Time.deltaTime;

        if(currentFireDelay >= fireDelay)
        {
            currentFireDelay = 0;

            switch(bulletPatterns)
            {
                case Pattern.Single:
                    {
                        SingleShot();
                        break;
                    }
                case Pattern.MultiStraight:
                    {
                        MultiFrontShot();
                        break;
                    }
                case Pattern.Multi:
                    {
                        MultiShot();
                        break;
                    }



            }
        }
    }

    void SingleShot()
    {
        Instantiate(bullets, transform.position, Quaternion.identity).direction = ShootDirection;
    }
    void MultiFrontShot()
    {
        int MiddleBull = bulletCountForMultiFront % 2;
        int SideBull = bulletCountForMultiFront / 2;

        
        if(MiddleBull == 0)
        {
            
            for(int i = 0; i < SideBull; i++)
            {
                float Xspacing = spacingX * (2 * i + 1);
                float Yspacing = spacingY * (2 * i + 1);
                Instantiate(bullets, transform.position + new Vector3(Xspacing,Mathf.Abs(Yspacing),0), Quaternion.identity).direction = ShootDirection;
                Instantiate(bullets, transform.position + new Vector3(-Yspacing, Mathf.Abs(Yspacing),0), Quaternion.identity).direction = ShootDirection;
            }
        }
        else
        {
            for (int i = 0; i < SideBull; i++)
            {
                float Xspacing = spacingX * (2 * (i+1) );
                float Yspacing = spacingY * (2 * (i+1) );
                Instantiate(bullets, transform.position + new Vector3(Xspacing, Mathf.Abs(Yspacing),0), Quaternion.identity).direction=ShootDirection;
                Instantiate(bullets, transform.position + new Vector3(-Xspacing, Mathf.Abs(Yspacing),0), Quaternion.identity).direction= ShootDirection;
            }
            Instantiate(bullets, transform.position, Quaternion.identity).direction = ShootDirection;
        }
    }

    void MultiShot()
    {
        int MiddleBull = bulletCountForMultiFront % 2;
        int SideBull = bulletCountForMultiFront / 2;

        if(MiddleBull == 0)
        {
            for(int i = 0; i < SideBull; i++)
            {
                float sideAngle = AngleSpacing * (2 * i + 1);

                float Xspacing = spacingX * (2 * i + 1);
                float Yspacing = spacingY * (2 * i + 1);
                Instantiate(bullets, transform.position + new Vector3(Xspacing, Mathf.Abs(Yspacing),0), Quaternion.identity).direction = VectorManipulation.SpinVector(ShootDirection,sideAngle);
                Instantiate(bullets, transform.position + new Vector3(-Yspacing, Mathf.Abs(Yspacing),0), Quaternion.identity).direction = VectorManipulation.SpinVector(ShootDirection, -sideAngle);
            }
        }
        

        else
        {
            for (int i = 0; i < SideBull; i++)
            {
                float sideAngle = AngleSpacing*(2 * (i + 1));
                float Xspacing = spacingX * (2 * (i + 1));
                float Yspacing = spacingY * (2 * (i + 1));
                Instantiate(bullets, transform.position + new Vector3(Xspacing, Mathf.Abs(Yspacing),0), Quaternion.identity).direction = VectorManipulation.SpinVector(ShootDirection, sideAngle);
                Instantiate(bullets, transform.position + new Vector3(-Xspacing, Mathf.Abs(Yspacing),0), Quaternion.identity).direction = VectorManipulation.SpinVector(ShootDirection, -sideAngle);
            }
            Instantiate(bullets, transform.position, Quaternion.identity).direction = ShootDirection;

        }
    }

}
