using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    public int maxHealth = 0;
    public int currentHealth;
    public healthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TakeDamage(-10);
        }
    }

    public void TakeDamage(int damage) // Tarkistaa, että healthbar ei mene yli tai ali
    {
        int oldHealth = currentHealth;
        currentHealth -= damage;

        //Tarkistaa, että terveyden arvo ei mene yli tai alle rajan
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        //Päivitä healthBar vain, jos terveyden arvo muuttuu
        if (oldHealth != currentHealth)
        {
            healthBar.SetHealth(currentHealth);
        }
    }
}