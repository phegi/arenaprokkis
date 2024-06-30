using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    [SerializeField]
    public enemyStatsSO enemyStats;
    public int enemyCurrentHealth;
    public int enemyContactDamage;
    public vihuHelaBaari healthBar;

    void Start()
    {
        int enemyMaxHealth = enemyStats.enemyMaxHealth;
        enemyCurrentHealth = enemyMaxHealth;
        healthBar.SetEnemyMaxHealth(enemyMaxHealth);
        enemyContactDamage = enemyStats.enemyContactDamage;
    }

    void Update()
    {
        healthBar.SetEnemyHealth(enemyCurrentHealth);
    }

    public void TakeDamage(int damageToEnemy) // maxhealth minhealth
    {
        int enemyOldHealth = enemyCurrentHealth;
        enemyCurrentHealth -= damageToEnemy;

        enemyCurrentHealth = Mathf.Clamp(enemyCurrentHealth, 0, enemyStats.enemyMaxHealth);

        if (enemyOldHealth != enemyCurrentHealth)
        {
            healthBar.SetEnemyHealth(enemyCurrentHealth);
        }
        if (enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
