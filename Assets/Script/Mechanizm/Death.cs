using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject prefabExplosion;
    // Start is called before the first frame update
    public void onDeath()
    {   
        
        Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
