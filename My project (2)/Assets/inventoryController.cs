using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryController : MonoBehaviour
{
    public void toggleInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            gameObject.SetActive(true);
        }
    }
}
