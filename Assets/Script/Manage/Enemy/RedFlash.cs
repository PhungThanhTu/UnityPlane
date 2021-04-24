using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFlash : MonoBehaviour
{
    SpriteRenderer SRenderer;

    public float flashingTime = 0.25f;
    float currentFlashingTime = 0;

    public Color flashColor = Color.red;
    bool isFlash = false;
    // Start is called before the first frame update
    void Start()
    {
        SRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFlash)
        {
            Flash();
        }
        else
        {
            UnFlash();
        }
        if(currentFlashingTime > 0)
        {
            isFlash = true;
            currentFlashingTime -= Time.deltaTime;
        }
        if(currentFlashingTime <= 0)
        {
            isFlash = false;
        }
        if(currentFlashingTime < 0)
        {
            currentFlashingTime = 0;
        }
    }
    void Flash()
    {
        SRenderer.color = flashColor;
    }
    void UnFlash()
    {
        SRenderer.color = Color.white;
    }

    public void StartFlash()
    {
        currentFlashingTime = flashingTime;
    }
}
