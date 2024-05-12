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
    public  PlayerBehaviour playerBehaviour;

    void Start()
    {
        UpdateHealthText();
    }

    
    public void SetMaxHealth (float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        helaMäärä.text = slider.value + "/" + playerBehaviour.maxHealth;
    }
    void UpdateHealthText() // teksti päivitetään void Startissa(), sekä joka kerta kun hela päivittyy.
    {
        helaMäärä.text = slider.value + "/" + playerBehaviour.maxHealth;
    }
}
