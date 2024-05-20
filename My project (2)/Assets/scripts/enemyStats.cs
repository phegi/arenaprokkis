using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : MonoBehaviour
{
    [SerializeField]
    public int enemyMaxHealth = 350;
    public int enemyCurrentHealth;
    public vihuHelaBaari healthBar;
    public ExpCounter expcounter;
    public PlayerBehaviour playerbehaviour;
    public EnemyDeathEvent enemydeathevent;

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
        if (enemyCurrentHealth <= 0)
        {
            enemydeathevent.EnemyDeath();
        }
    }
}

/* switch (enemyType)
         {
            case "valkoMonsu":
                SetEnemyStats
                (
                    health;
                    damage;
                    speed;
                    knockbackRes;
                    damageRes;
                )
                break;

            case "normiMonsu":
                SetEnemyStats
                (
                    health;
                    damage;
                    speed;
                    knockbackRes;
                    damageRes;
                )
                break;
            
            case "mangoLoco":
                SetEnemyStats
                (
                    health;
                    damage;
                    speed;
                    knockbackRes; 
                    damageRes;
                )
                break;
         }*/

         /*
        void SetEnemyStats (float health, float damage, float speed, float knockbackRes, float damageRes)
        {
            EnemyStats stats = GetComponent<EnemyStats>();
            if (stats != null)
        {
            stats.health = health;
            stats.damage = damage;
            stats.speed = speed
        }
        }
    */