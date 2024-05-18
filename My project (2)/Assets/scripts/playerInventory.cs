using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    public Inventory inventory;
    public ItemTypeOrganizer itemTypeOrg;
    public List<ItemType> itemTypes = new List<ItemType>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckIfItem(collision);
    }

    private void CheckIfItem(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            GrabItemByItemType(collision.gameObject);
        }
        Destroy(collision.gameObject);
    }

    private void GrabItemByItemType(GameObject item)
    {
        inventory.AddItem(item);
        Debug.Log("this item was added: " + item.name);
        Debug.Log($"Added item of type: {item}");
    }
}
