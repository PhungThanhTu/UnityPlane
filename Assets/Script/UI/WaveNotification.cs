using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveNotification : MonoBehaviour
{
    public Text txtNotification;

    public float LivingTime = 2;
    float currentLivingTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentLivingTime += Time.deltaTime;
        if(currentLivingTime >= LivingTime)
        {
            Destroy(gameObject);
        }
    }
    public void setNoti(string noti)
    {
        txtNotification.text = noti;
    }
}
