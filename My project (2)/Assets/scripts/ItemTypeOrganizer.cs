using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ItemType
{
    currency,
    weapon,
    consumable,
    ammo,
    food,
    questItem,
    key,
    powerUp,
    collectible
}
public class ItemTypeOrganizer : MonoBehaviour
{
    public GameObject uiButton;
    public ItemType itemType;
    public string itemName;
}