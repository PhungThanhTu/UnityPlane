using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Warning : MonoBehaviour
{
    public Image bgWarning;
    public float FlashTime = 0.75f;
    float currentFlashTime;
    public GameObject boss;

    public float warningTime = 3;
    public bool isFlash = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentFlashTime += Time.deltaTime;
        if(currentFlashTime >= FlashTime)
        {
            isFlash = !isFlash;
            currentFlashTime = 0;
        }
        warningTime -= Time.deltaTime;
        if(warningTime < 0)
        {
            Instantiate(boss);
            
            Destroy(gameObject);
        }

        if (isFlash)
        {
            bgWarning.enabled = false;
        
        }
        else
        {
            bgWarning.enabled = true;
        }
    }
}