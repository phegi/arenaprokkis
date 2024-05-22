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
    public GameObject ItemStackCount;

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
        //jotenki update itemstackcount täs
    }

    public void getItemDetails(string itemName, int quantity)
    {
        var itemDetails = inventory.GetItemDetails(itemName);
        if (itemDetails.itemName != null)
        {
            Debug.Log($"Item: {itemDetails.itemName}, Quantity: {itemDetails.quantity}");
        }
    }


    public void getItemsToInventory(GameObject _item)
    {
        var itemDetails = inventory.GetItemDetails(_item.name);
        foreach (Button prefab in prefabs)
        {
            string prefabName = prefab.name;
            if (prefabName.Contains(_item.name) && inventory.ItemCount < 16)
            {
                // Instantiate the button prefab
                Button instantiatedButton = Instantiate(prefab, parentObject);

                // Instantiate the itemStackCount prefab
                GameObject itemStackCount = Instantiate(ItemStackCount);

                // Set the instantiated button as the parent of the itemStackCount object
                itemStackCount.transform.SetParent(instantiatedButton.transform);

                // Position the itemStackCount object on top of the instantiatedButton
                Vector2 itemStackCountPosition = new Vector2(
                    instantiatedButton.transform.position.x + 18,
                    instantiatedButton.transform.position.y + 18
                );
                itemStackCount.transform.position = itemStackCountPosition;

                countItemStack(itemStackCount);
            }
        }
    }

    public void countItemStack(GameObject itemStackCount)
    {
        foreach (var item in inventory.GetItems)
        {
            getItemDetails(item.item, item.quantity);
            int itemQuantity = item.quantity;
            itemStackCount.GetComponent<TextMeshProUGUI>().text = itemQuantity.ToString() + "x";
        }
    }
}
