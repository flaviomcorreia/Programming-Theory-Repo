using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public GameObject powerup;
    public float spawnRange = 9f;

    private int enemyCount;
    private int waveNumber = 1;
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup(waveNumber);
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if(enemyCount == 0){
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup(waveNumber-1);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn){
        for(int i = 0; i < enemiesToSpawn; i++){
            Instantiate(enemy, GenerateSpawnPosition(), enemy.transform.rotation);
        }
    }
    void SpawnPowerup(int enemiesToSpawn){
        for(int i = 0; i < enemiesToSpawn; i++){
            Instantiate(powerup, GenerateSpawnPosition(), powerup.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);

        return randomPos;

    }
}
