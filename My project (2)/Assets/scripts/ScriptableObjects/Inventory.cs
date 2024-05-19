using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    [System.Serializable]
    public class InventoryItem
    {
        public GameObject item;
        public int quantity;
    }

    [SerializeField] List<InventoryItem> items = new List<InventoryItem>();

    public List<InventoryItem> GetItems
    {
        get => items;
    }

    public void AddItem(GameObject itemToAdd)
    {
        InventoryItem existingItem = items.Find(i => i.item == itemToAdd);
        
        if (itemToAdd.Equals(existingItem))
        {
            existingItem.quantity++;
        }
        else
        {
            string itemName = itemToAdd.name;

            InventoryItem newItem = new InventoryItem { item = itemToAdd, quantity = 1 };
            items.Add(newItem);
            Debug.Log($"Added{newItem}");
        }
    }

    public void UpdateItemValue()
    {
        // Implementation for updating item values, if needed
    }
}