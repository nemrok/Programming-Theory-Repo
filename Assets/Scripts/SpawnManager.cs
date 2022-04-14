using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;
    public GameObject prey;

    private float zEnemySpawn = 12.0f;
    private float xSpawnRange = 12.0f;
    private float zPowerupRange = 5.0f;
    private float zPreyRange = -8.0f;
    private float yEnemySpawn = 0.75f;
    private float yPreySpawn = 0.04f;
    private float enemySpawnTime = 0.5f;
    private float powerupSpawnTime = 5.0f;
    private float preySpawnTime = 1.0f;
    private float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
        InvokeRepeating("SpawnPrey", startDelay, preySpawnTime);
    }

    void SpawnRandomEnemy()
    {
        if (!GameManager.Instance().IsGameOver)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, enemies.Length);
            Vector3 spawnPos = new Vector3(randomX, yEnemySpawn, zEnemySpawn);

            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        }
    }

    void SpawnPowerup()
    {
        if (!GameManager.Instance().IsGameOver)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            float randomZ = Random.Range(-zPowerupRange, zPowerupRange);
            Vector3 spawnPos = new Vector3(randomX, yEnemySpawn, randomZ);

            Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
        }
    }

    void SpawnPrey()
    {
        if (!GameManager.Instance().IsGameOver)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);        
            Vector3 spawnPos = new Vector3(randomX, yPreySpawn, zPreyRange);

            Instantiate(prey, spawnPos, prey.gameObject.transform.rotation);
        }
    }
}
 