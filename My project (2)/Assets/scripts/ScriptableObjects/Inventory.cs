using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] List<GameObject> items = new List<GameObject>();
    public List<GameObject> GetItems
    {
        get => items;
    }
    public void AddItem(GameObject itemToAdd) { items.Add(itemToAdd); }
}
