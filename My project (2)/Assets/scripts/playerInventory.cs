using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class playerInventory : MonoBehaviour
{
    public Inventory inventory;
    public ItemTypeOrganizer itemTypeOrg;
    public List<ItemType> itemTypes = new List<ItemType>();
    public Transform parentObject;
    public Button[] prefabs;
    public TextMeshProUGUI itemMäärä;

    void Start()
    {
        //Check inventory.cs for items and instantiate them in inventory
        /* foreach (var item in inventory.GetItems)
         {
             getItemDetails(item.item, item.quantity);
             string itemName = item.item;
             if (item != null)
             {
                 foreach (Button prefab in prefabs)
                 {
                     if (prefab.name.Contains(itemName) && inventory.ItemCount < 16 || inventory.items.Contains(prefab.name))
                     {
                         Instantiate(prefab, parentObject);
                     }
                 }
             }
         }*/

    }

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

    private void GrabItemByItemType(GameObject _item)
    {
        inventory.AddItem(_item);
        getItemsToInventory(_item);
        Debug.Log(_item.name + " picked up");
    }

    void getItemDetails(string itemName, int quantity)
     {
         var itemDetails = inventory.GetItemDetails(itemName);
         if (itemDetails.itemName != null)
         {
             Debug.Log($"Item: {itemDetails.itemName}, Quantity: {itemDetails.quantity}");
         }
     }    
     

    public void getItemsToInventory(GameObject _item)
    {
        foreach (Button prefab in prefabs)
        {
            string prefabName = prefab.name;
            Debug.Log($"Checking if prefab {prefab.name} exists in itemTypes list...");
            if (prefabName.Contains(_item.name) && inventory.ItemCount < 16)
            {
                Debug.Log($"Prefab {prefab.name} exists in itemTypes list, instantiating...");
                Instantiate(prefab, parentObject);
                Debug.Log("Prefab instantiated.");
                countItems();
            }
            else
            {
                Debug.LogError($"Prefab {prefab.name} does not exist in itemTypes list.");
            }
        }
    }
    public void countItems()
    {
        foreach (var item in inventory.GetItems)
        {
            
            getItemDetails(item.item, item.quantity);
            int itemQuantity = item.quantity;
            itemMäärä.text = itemQuantity.ToString();
        }
    }
}
