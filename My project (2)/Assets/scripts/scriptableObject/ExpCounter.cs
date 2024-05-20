using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


[CreateAssetMenu(fileName = "NewExpCounter", menuName = "NewExpCounter")]
public class ExpCounter : ScriptableObject
{
    [SerializeField] float exp = 0;
    [SerializeField] int level = 1;
    [SerializeField] float expToNextLevel = 10;
    public float GetExp { get => exp; }
    public int GetLevel { get => level; }
    public float GetExpToNextLevel { get => expToNextLevel; }
    public void UpdateExp(int gottedExp) { exp += gottedExp; }
    public void UpdateLevel() { level++; }
    public void UpdateExpToNextLevel() { expToNextLevel *= 1.2f; }
    public void ResetExp() { exp = 0; }

}
