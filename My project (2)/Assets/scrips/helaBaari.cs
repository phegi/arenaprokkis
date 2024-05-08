using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class helaBaari : MonoBehaviour
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

    
    public void SetMaxHealth (int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        helaMäärä.text = slider.value + "/" + playerStats.maxHealth;
    }
    void UpdateHealthText() // teksti päivitetään void Startissa(), sekä joka kerta kun hela päivittyy.
    {
        helaMäärä.text = slider.value + "/" + playerStats.maxHealth;
    }
}
