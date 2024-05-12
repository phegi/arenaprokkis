using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{

    public bool gamePaused = false;
    [SerializeField]
    GameObject _pauseMenu = null;

    public void pauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused)
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
            gamePaused = true;
        }
        else
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1;
            gamePaused = false;
        }
    }
}
