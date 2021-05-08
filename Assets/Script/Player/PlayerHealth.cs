using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;


    public Transform gameUI;
    public ValueBar healthBar;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetValue(currentHealth);

       
    }

    private void Start()
    {
        gameUI = GameObject.Find("gameUI").transform;
        healthBar = Instantiate(Resources.Load("UI/Health") as GameObject, gameUI).GetComponent<ValueBar>();
        healthBar.SetMaxValue(maxHealth);
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            this.GetComponent<Death>().onDeath();
            GameObject.Find("TheGameManager").GetComponent<Game>().GameOver();
        }
    }
    private void OnDestroy()
    {
 
    }
}
