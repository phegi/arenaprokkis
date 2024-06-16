using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class vihuHelaBaari : MonoBehaviour
{
    public Slider slider1;
    public Image fill1;
    public enemyStats enemyStats;


    public void SetEnemyMaxHealth()
    {
        slider1.maxValue = enemyStats.enemyMaxHealth;
        slider1.value = slider1.maxValue;
    }

    public void SetEnemyHealth(int health)
    {
        slider1.value = health;
    }
}
