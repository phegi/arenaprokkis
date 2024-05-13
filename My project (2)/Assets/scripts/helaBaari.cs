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
    public PlayerBehaviour playerBehaviour;

    void Start()
    {
        updateHealthText();
        fill.color = gradient.Evaluate(1f);
    }
    public void SetMaxHealth()
    {
        slider.maxValue = playerBehaviour.GetStat(PlayerBehaviour.Stat.maxHealth);
        slider.value = playerBehaviour.GetStat(PlayerBehaviour.Stat.currentHealth);
    }
    public void SetHealth()
    {
        slider.value = playerBehaviour.GetStat(PlayerBehaviour.Stat.currentHealth);
        fill.color = gradient.Evaluate(slider.normalizedValue);
        helaMäärä.text = playerBehaviour.GetStat(PlayerBehaviour.Stat.currentHealth) + "/" + playerBehaviour.GetStat(PlayerBehaviour.Stat.maxHealth);
    }
    public void updateHealthText()
    {
        helaMäärä.text = playerBehaviour.GetStat(PlayerBehaviour.Stat.currentHealth) + "/" + playerBehaviour.GetStat(PlayerBehaviour.Stat.maxHealth);
    }
    


    /* public void SetMaxHealth(float health)
     {
         slider.maxValue = health;
         slider.value = health;

         fill.color = gradient.Evaluate(1f);
     }

     public void SetHealth(float health)
     {
         SetMaxHealth(health);
         slider.value = health;
         fill.color = gradient.Evaluate(slider.normalizedValue);
         // helaMäärä.text = slider.value + "/" + playerBehaviour.maxHealth;
         helaMäärä.text = slider.value + "/" + playerBehaviour.GetStat(PlayerBehaviour.Stat.maxHealth);
     }
     void UpdateHealthText() // teksti päivitetään void Startissa(), sekä joka kerta kun hela päivittyy.
     {
         helaMäärä.text = slider.value + "/" + playerBehaviour.GetStat(PlayerBehaviour.Stat.maxHealth);
         Debug.Log(playerBehaviour.GetStat(PlayerBehaviour.Stat.maxHealth));
     }
     */
}

