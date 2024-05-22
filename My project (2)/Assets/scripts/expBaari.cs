using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class expBaari : MonoBehaviour
{
    public Slider slider;
    public PlayerBehaviour playerBehaviour;
    public ExpCounter expcounter;
    public TextMeshProUGUI xpLevelText;

    void Start()
    {
        expcounter.ResetExpStart();
        Debug.Log("expan määrä on tällähetkellä = " + expcounter.GetExp);
        SetExpBar();
    }

    public void SetExpBar()
    {
        slider.maxValue = expcounter.GetExpToNextLevel;
        slider.value = expcounter.GetExp;
        xpLevelText.text = expcounter.GetLevel.ToString();
    }

    public void UpdateExpBar()
    {
        slider.value = expcounter.GetExp;
    }
}
