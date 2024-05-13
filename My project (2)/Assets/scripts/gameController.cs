using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public kuolemaRuutu kuolemaRuutu;
    public PlayerBehaviour playerBehaviour;
    public pauseMenu pauseMenu;

    void Update()
    {
        if (playerBehaviour.GetStat(PlayerBehaviour.Stat.currentHealth) <= 0)
        {
            kuolemaRuutu.Setup();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.pauseGame();
        }
    }
}

