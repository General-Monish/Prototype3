using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerv : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject powerUpPrefab;
    float spawnRange = 9f;
    public int enemyCount;
    int waveNumber=1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(waveNumber);
        Instantiate(powerUpPrefab, GenerateRandomSpawnPositions(), powerUpPrefab.transform.rotation);
    }

    void SpawnEnemies(int enemiesToSpaen)
    {
        for(int i = 0; i < enemiesToSpaen; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomSpawnPositions(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount=FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemies(waveNumber);
            Instantiate(powerUpPrefab,GenerateRandomSpawnPositions(), powerUpPrefab.transform.rotation);
        }
    }

    Vector3 GenerateRandomSpawnPositions()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);
        return randomPosition;
    }
}
