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


public void SetEnemyMaxHealth(int health)
{
    slider1.maxValue = health;
    slider1.value = health;
}

public void SetEnemyHealth(int health)
{
    slider1.value = health;
}
}
