using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public kuolemaRuutu kuolemaRuutu;
    public PlayerBehaviour playerBehaviour;
    public pauseMenu pauseMenu;
    public inventoryControls inventoryControls;
    public GameObject consum1;
    public GameObject consum2;
    


    void Start()
    {
        Instantiate(consum1);
        Instantiate(consum2);
        Instantiate(consum1);
        Instantiate(consum2);
        Instantiate(consum1);
        Instantiate(consum2);
    }
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryControls.openInventory();
        }
    }
}

