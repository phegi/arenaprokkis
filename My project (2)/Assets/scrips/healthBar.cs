using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class healthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    [SerializeField]
    public TextMeshProUGUI helaMäärä;
    public playerStats playerStats;

    void Start()
    {
        UpdateHealthText();
    }
    void Update()
    {
        //playerStats.currentHealth -= playerStats.damage
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value =  health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        Debug.Log("lollero");
        helaMäärä.text = slider.value + "/" + playerStats.maxHealth;
    }
    void UpdateHealthText() //teksti päivitetään void Startissa(), sekä joka kerta kun health päivittyy
    {
        helaMäärä.text = slider.value + "/" + playerStats.maxHealth;
    }
}