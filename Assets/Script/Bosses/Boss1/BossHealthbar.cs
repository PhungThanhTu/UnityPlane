using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealthbar : MonoBehaviour
{
    public Health health;


    public Slider slider;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {   if(health == null)
        {
            Destroy(gameObject);
        }
        slider.transform.position = Camera.main.WorldToScreenPoint(health.gameObject.transform.position + offset);
        SetHeath();
    }

    public void SetMaxHealth()
    {
        slider.value = health.maxHealth;
        slider.maxValue = health.maxHealth;
    }
    public void SetHeath()
    {
        slider.value = health.currentHealth;
    }

}
