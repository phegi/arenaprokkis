using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "newEnemyStats", menuName = "EnemyStats")]
public class enemyStatsSO : ScriptableObject
{
    [SerializeField] public int enemyMaxHealth;
    [SerializeField] public int enemyContactDamage;
    [SerializeField] public int enemySpeed;

public int getEnemyMaxHealth { get => enemyMaxHealth; }
public int getEnemyContactDamage { get => enemyContactDamage; }
public int getEnemySpeed { get => enemySpeed; }

}
public class enemyStats : MonoBehaviour
{
    private enemyStatsSO enemyStatsSO;
    public int getEnemyMaxHealth { get => enemyStatsSO.enemyMaxHealth; }
    public int getEnemyContactDamage { get => enemyStatsSO.enemyContactDamage; }
    public int getEnemySpeed { get => enemyStatsSO.enemySpeed; }
}
