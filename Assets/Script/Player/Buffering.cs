using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffering : MonoBehaviour
{

    SpriteRenderer playerSprite;
    BoxCollider2D playerCollider;
    public float duration = 1;
    public float interval = 0.1f;

    float currentDuration = 0;
    float currentInterval = 0;
    //Start
    private void Start()
    {
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if(currentDuration > 0)
        {
            currentDuration -= Time.deltaTime;
            currentInterval -= Time.deltaTime;

            if(currentInterval <= 0)
            {
                AnimationFlash();
                currentInterval = interval;
            }
        }
        else
        {
            currentDuration = 0;
            StopBuffering();
        }
    }

    void AnimationFlash()
    {
        playerSprite.enabled = !playerSprite.enabled;
    }
    void StopBuffering()
    {
        playerSprite.enabled = true;
    }
    public void StartBuffering()
    {
        playerSprite.enabled = false;
        currentDuration = duration;
    }
}
