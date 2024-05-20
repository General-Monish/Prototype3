using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerLab : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    [SerializeField] GameObject powerUp;

    float zBound = 6f;
    float xBound = 11f;
    float powerZBound = 5f;
    float startDelay = 2f;
    float spawnInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", startDelay, spawnInterval);
        InvokeRepeating("SpawnPowerUp", startDelay, spawnInterval);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnPowerUp()
    {
        float randomX = Random.Range(-xBound, xBound);
        float randomZ = Random.Range(-powerZBound, powerZBound);
        Vector3 powerSpawnPos = new Vector3(randomX, .5f, randomZ);
        Instantiate(powerUp, powerSpawnPos, Quaternion.identity);
    }

    private void SpawnEnemies()
    {
        float randomX = Random.Range(-xBound, xBound);
        int RandomEnemiesIndex = Random.Range(0, enemy.Length);
        Vector3 spawnPositions = new Vector3(randomX, .5f, zBound);
        Instantiate(enemy[RandomEnemiesIndex], spawnPositions, enemy[RandomEnemiesIndex].gameObject.transform.rotation);
    }

}
