using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class kuolemaRuutu : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void restartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void mainMenuButton()
    {
        Debug.Log("Work in progress");
    }
}
