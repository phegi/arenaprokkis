using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryItem
{
    //  koiraCurrency_btn,
    //  piskiCollectible_btn,
    //  currency,
    //  weapon,
    //  consumable,
    //  ammo,
    //  food,
    //  questItem,
    //  key,
    //  powerUp,
    //  collectible
}

public class InventoryItemBehavior : MonoBehaviour
{
    public ItemType itemType;
    public string itemName;
    public string itemDescription;
    public int itemStackCount;
    public int itemCoords;
}