using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Speed = 10;
    Vector3 direction = Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        this.transform.rotation = Quaternion.Euler(0,0,Angle);
        if(FaceToClosestEnemy() != Vector3.zero)
        {
            direction = FaceToClosestEnemy();
        }
        this.transform.position += direction * Speed*Time.deltaTime;
    }

    Vector3 FaceToClosestEnemy()
    {
        Vector3 FacingDir = new Vector3(0,0,0);
        GameObject[] target = GameObject.FindGameObjectsWithTag("Enemy");
        float minDist = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach(GameObject closestTarget in target)
        {   if(closestTarget != null)
            {
                float calcingDistance = Vector3.Distance(this.transform.position, closestTarget.transform.position);
                if (calcingDistance <= minDist)
                {
                    minDist = calcingDistance;
                    closestEnemy = closestTarget;
                }
            }
        if(target.Length > 0)
        {
                FacingDir = (closestEnemy.transform.position - this.transform.position).normalized;
        }
        else
        {
                FacingDir = Vector3.zero;
        }
            
        }
        return FacingDir;

    }
    Vector3 RotatingVector(Vector3 vector, float Angle)
    {
        Vector3 resVector = Vector3.zero;

        float SinAng = Mathf.Sin(Angle * Mathf.Deg2Rad);
        float CosAng = Mathf.Cos(Angle * Mathf.Deg2Rad);


        return resVector;
    }
    
}
