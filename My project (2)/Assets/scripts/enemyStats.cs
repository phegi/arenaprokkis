using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : MonoBehaviour
{
    [SerializeField]
    public int enemyMaxHealth = 350;
    public int enemyCurrentHealth;
    public vihuHelaBaari healthBar;

    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        healthBar.SetEnemyHealth(enemyMaxHealth);
    }

    void Update()
    {
        healthBar.SetEnemyHealth(enemyCurrentHealth);
    }

    public void TakeDamage(int enemyDamage) // maxhealth minhealth
    {
        int enemyOldHealth = enemyCurrentHealth;
        enemyCurrentHealth -= enemyDamage;

        enemyCurrentHealth = Mathf.Clamp(enemyCurrentHealth, 0, enemyMaxHealth);

        if (enemyOldHealth != enemyCurrentHealth)
        {
            healthBar.SetEnemyHealth(enemyCurrentHealth);
        }
    }
}
