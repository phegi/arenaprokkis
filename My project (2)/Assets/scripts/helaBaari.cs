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
}

