using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalClass 
{
  
}

public static class VectorManipulation
{
    public static Vector3 SpinVector(Vector3 origional,float angle)
    {
        Vector3 result = new Vector3();

        float angleInRad = angle * Mathf.Deg2Rad;

        float resX = origional.x * Mathf.Cos(angleInRad) - origional.y * Mathf.Sin(angleInRad);
        float resY = origional.x * Mathf.Sin(angleInRad) + origional.y * Mathf.Cos(angleInRad);
        float resZ = origional.z;

        result = new Vector3(resX, resY, resZ);
        return result;
    }
}
