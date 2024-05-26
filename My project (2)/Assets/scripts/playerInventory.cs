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
        Debug.Log("block1");
    }

    private void GrabItemByItemType(GameObject item)
    {
        inventory.AddItem(item);
        getItemsToInventory();
        Debug.Log(item.name + " picked up");
        //jotenki update itemstackcount täs
    }

    public void getItemDetails(string _itemName, int quantity)
    {
        var itemDetails = inventory.GetItemDetails(_itemName);
        if (itemDetails.itemName != null)
        {
            Debug.Log($"Item: {itemDetails.itemName}, Quantity: {itemDetails.quantity}");
        }
    }


    public void getItemsToInventory()
    {
        foreach (var item in inventory.GetItems)
        {
            getItemDetails(item.item, item.quantity);
            string itemName = itemTypeOrg.itemName;

            foreach (Button prefab in prefabs)
            {
                string prefabName = prefab.name;
                if (prefabName.Contains(itemName) && prefabName != null)
                {
                    // Instantiate the button prefab
                    Button instantiatedButton = Instantiate(prefab, parentObject);

                    // Instantiate the itemStackCount prefab
                    GameObject itemStackCount = Instantiate(ItemStackCount);

                    // Set the instantiated button as the parent of the itemStackCount object
                    itemStackCount.transform.SetParent(instantiatedButton.transform);

                    // Position the itemStackCount object on top of the instantiatedButton
                    Vector2 itemStackCountPosition = new Vector2
                    (
                        instantiatedButton.transform.position.x + 18,
                        instantiatedButton.transform.position.y + 18
                    );

                    itemStackCount.transform.position = itemStackCountPosition;

                    countItemStack(itemStackCount, itemName);
                }
            }
        }
    }

    public void countItemStack(GameObject itemStackCount, string itemName)
    {
        foreach (var item in inventory.GetItems)
        {
            getItemDetails(item.item, item.quantity);
            int itemQuantity = item.quantity;
            itemName = itemTypeOrg.itemName;

            // Get the name of the itemStackCount object's parent
            // Tarvitaan parentin nimi, että itemStackCount value menee oikeeseen buttoniin
            string spaghetti = itemStackCount.transform.parent.gameObject.name;
            string parentName = spaghetti.Split('(')[0];

            //string lisäEhto = "(Clone)";
            Debug.Log(itemName);
            Debug.Log(spaghetti);

            if (parentName.Contains(itemName) && parentName != null)//spaghettikki
            {
                itemStackCount.GetComponent<TextMeshProUGUI>().text = itemQuantity.ToString() + "x";
                break;
            }
        }
    }
}

