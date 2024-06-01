using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inventoryControls : MonoBehaviour
{
    public bool inventoryOpen = false;
    [SerializeField] 
    GameObject inventoryUI = null;

    public void openInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !inventoryOpen)
        {
            //Debug.Log("Yeah...");
            inventoryUI.SetActive(true);
            inventoryOpen = true;
            
        }
        else
        {
            inventoryUI.SetActive(false);
            inventoryOpen = false;
        }
    }
}