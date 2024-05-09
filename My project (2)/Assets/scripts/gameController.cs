using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public kuolemaRuutu kuolemaRuutu;
    public playerStats playerStats;

    void Update()
    {
        if (playerStats.currentHealth == 0)
        {
            kuolemaRuutu.Setup();
        }
    }
} 
