using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 100;
    public int currentHealth;

    public helaBaari healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            TakeDamage(10);
        }
    }


    public void TakeDamage(int damage) //tarkistaa, että hela ei mene yli maxHealth ja alle 0
    {
        int oldHealth = currentHealth;
        currentHealth -= damage;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (oldHealth != currentHealth)
        {
            healthBar.SetHealth(currentHealth);
        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
