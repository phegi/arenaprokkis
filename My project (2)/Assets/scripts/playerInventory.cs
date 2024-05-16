using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    public Inventory inventory;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item")) //INVENTORY
        {
            inventory.UpdateCoins(1);
            Destroy(collision.gameObject);
        }
    }
}
