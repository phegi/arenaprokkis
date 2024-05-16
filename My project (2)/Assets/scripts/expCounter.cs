using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


[CreateAssetMenu(fileName = "expCounter.cs", menuName = "expCounter")]
public class expCounter : ScriptableObject
{
    [SerializeField] int exp = 0;
    [SerializeField] int level = 1;
    [SerializeField] int expToNextLevel = 10;
    public int GetExp { get => exp; }
    public int GetLevel { get => level; }
    public int GetExpToNextLevel { get => expToNextLevel; }
    public void UpdateExp(int gottedExp) { exp += gottedExp; }
    public void UpdateLevel() { level++; }
    public void UpdateExpToNextLevel() { expToNextLevel *= 2; }
    public void ResetExp() { exp = 0; }

}