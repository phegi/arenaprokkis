using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landingButton : MonoBehaviour
{
    [SerializeField] private GameObject InventoryCanvas;
    private bool inventoryActive = false;

    public void activateInventoryCanvas()
    {
        if (!inventoryActive)
        {
            InventoryCanvas.SetActive(true);
            inventoryActive = true;
        }
        else
        {
            InventoryCanvas.SetActive(false);
            inventoryActive = false;
        }
    }
}
