using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class playerInventory : MonoBehaviour
{
    public Inventory inventory;
    public ItemTypeOrganizer itemTypeOrg;
    public List<ItemType> itemTypes = new List<ItemType>();
    public Transform parentObject;
    public Button[] prefabs;

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

    void getItemDetails(string itemName, int quantity)
    {
        var itemDetails = inventory.GetItemDetails("itemNameToSearch");
        if (itemDetails.itemName != null)
        {
            Debug.Log($"Item: {itemDetails.itemName}, Quantity: {itemDetails.quantity}");
        }
    }

    public void getItemsToInventory()
    {
        foreach (Button prefab in prefabs)
        {
            Instantiate(prefab, parentObject);
            Debug.Log("prefab instantiated");
        }
    }
}
