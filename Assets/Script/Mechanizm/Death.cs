using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject prefabExplosion;

    public GameObject drop1;
    public GameObject drop2;
    public GameObject drop3;
    public GameObject drop4;
    public GameObject goldDrop;
    public GameObject diamondDrop;

    public float ranNum;
    
    // Start is called before the first frame update
    public void onDeath()
    {
        if(gameObject.tag != "Player")
        {
            ranNum = Random.Range(0f, 1f);

            if (ranNum > 0 && ranNum < 0.2)
            {
                Instantiate(drop1, transform.position, Quaternion.identity);
            }
            if (ranNum > 0.2 && ranNum < 0.4)
            {
                Instantiate(drop2, transform.position, Quaternion.identity);
            }
            if (ranNum > 0.4 && ranNum < 0.6)
            {
                Instantiate(drop3, transform.position, Quaternion.identity);
            }
            if (ranNum > 0.6 && ranNum < 0.8)
            {
                Instantiate(drop4, transform.position, Quaternion.identity);
            }


           
        }
        Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
  
}
