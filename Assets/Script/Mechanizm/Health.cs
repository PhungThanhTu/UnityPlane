using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public bool Invincible = false;

    public RedFlash flasher;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        if(!Invincible)
        {
            currentHealth -= damage;
            flasher.StartFlash();
        }

        
    }
    private void Update()
    {
        if(currentHealth <= 0)
        {
            this.GetComponent<Death>().onDeath();
        }
    }
}
