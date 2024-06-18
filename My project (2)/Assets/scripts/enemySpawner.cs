using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject valkoMonsu;
    [SerializeField] private GameObject valkoMonsuBrute;

    [SerializeField]
    [Tooltip("Spawn rate in seconds")]
    private float valkoMonsuSpawnRate = 3.5f;

    [SerializeField]
    [Tooltip("Spawn rate in seconds")]
    private float valkoMonsuBruteSpawnRate = 10f;

    void Start()
    {
        var playerAlive = GameObject.FindGameObjectsWithTag("Player");
        if (playerAlive != null)
        {
            StartCoroutine(spawnEnemy(valkoMonsuSpawnRate, valkoMonsu));
            StartCoroutine(spawnEnemy(valkoMonsuBruteSpawnRate, valkoMonsuBrute));
        }
    }

    // jokainen uusi vihollinen vaatii spawn raten ja 
    // vihollisen prefabin referoinnin
    private IEnumerator spawnEnemy(float spawnRate, GameObject enemy) // spawnaa vihuja spawn ratejen mukaan
    {
        yield return new WaitForSeconds(spawnRate);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(spawnRate, enemy)); // vaatii kaksi parametria kuten näkee void Startissa()
    }
}
