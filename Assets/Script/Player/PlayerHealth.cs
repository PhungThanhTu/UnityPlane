using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            this.GetComponent<Death>().onDeath();
        }
    }
}
