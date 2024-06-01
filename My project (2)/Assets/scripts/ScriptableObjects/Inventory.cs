using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    [System.Serializable]
    public class InventoryItem
    {
        public string item;
        public int quantity;
    }

    [SerializeField] List<InventoryItem> items = new List<InventoryItem>();
    

    //Get amount of items in list
    public int ItemCount
    {
        get => items.Count;
    }

    public List<InventoryItem> GetItems
    {
        get => items;
    }


    public void AddItem(GameObject itemToAdd)
    {
        // Get the item name from the ItemTypeOrganizer component of the itemToAdd GameObject
        string _itemName = itemToAdd.GetComponent<ItemTypeOrganizer>().itemName;

        // Find the existing InventoryItem with the same item name
        InventoryItem existingItem = items.Find(i => i.item == _itemName);

        if (existingItem != null)
        {
            // If the item already exists, increment its quantity
            existingItem.quantity++;
        }
        else
        {
            // If the item does not exist, create a new InventoryItem and add it to the inventory
            InventoryItem newItem = new InventoryItem { item = _itemName, quantity = 1 };
            items.Add(newItem);
            Debug.Log($"Added{newItem}");
        }
    }

    public void UpdateItemValue()
    {
        // Implementation for updating item values, if needed
    }

    public (int quantity, string itemName) GetItemDetails(string itemName)
    {
        InventoryItem item = items.Find(i => i.item == itemName.Split('(')[0]);
        if (item != null)
        {
            return (item.quantity, item.item);
        }
        else
        {
            Debug.LogWarning($"Item {itemName} not found in inventory.");
            return (0, null);
        }
    }
}
