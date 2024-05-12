using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public kuolemaRuutu kuolemaRuutu;
    public playerStats playerStats;
    public pauseMenu pauseMenu;

    void Update()
    {
        if (playerStats.currentHealth == 0)
        {
            kuolemaRuutu.Setup();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.pauseGame();
        }
    }
}

