using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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
        Button[] allButtons = parentObject.GetComponentsInChildren<Button>(true); // Include inactive buttons in the search.
        Button existingButton = allButtons.FirstOrDefault(button => button.name == _item.name);

        if (existingButton != null)
        {
            Transform existingItemStackCountTransform = existingButton.transform.Find("ItemStackCount(Clone)");

            if (existingItemStackCountTransform != null)
            {
                TextMeshProUGUI itemStackCountText = existingItemStackCountTransform.GetComponent<TextMeshProUGUI>();

                if (itemStackCountText != null)
                {
                    // Update the TextMeshProUGUI with the new quantity.
                    // You need to implement the logic to determine the correct quantity.
                    // For example, if you have a method in your inventory that returns the current count of an item:
                    int quantity = itemDetails.quantity;
                    itemStackCountText.text = quantity.ToString() + "x";
                }
                else
                {
                    Debug.LogError("The ItemStackCount GameObject is missing a TextMeshProUGUI component.");
                }
            }
            else
            {
                Debug.LogError("ItemStackCount transform not found as a child of the existing button. Check the prefab to ensure it is correctly named and present.");
            }
        }
        else if (inventory.ItemCount < 16)
        {
            // No existing button found, create a new one if there's room in the inventory.
            Button prefab = prefabs.FirstOrDefault(p => p.name.Contains(_item.name));
            if (prefab != null)
            {
                Button instantiatedButton = Instantiate(prefab, parentObject.transform);
                instantiatedButton.name = _item.name; // Ensure the instantiated button has the correct name.

                // Instantiate the itemStackCount prefab and set up...
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
            else
            {
                Debug.LogError("Button prefab not found for item: " + _item.name);
            }
        }
        else
        {
            Debug.LogWarning("Inventory is full, cannot add more items.");
        }
    }

    public void countItemStack(GameObject itemStackCount)
    {
        foreach (var item in inventory.GetItems)
        {
            getItemDetails(item.item, item.quantity);
            int itemQuantity = item.quantity;
            string itemName = item.item;

            if (itemStackCount.transform.parent.gameObject.name.Contains(itemName))//spaghettikki
            {
                itemStackCount.GetComponent<TextMeshProUGUI>().text = itemQuantity.ToString() + "x";
            }
        }
    }

}
