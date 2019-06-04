using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    public Vector3[] spawnPositions;

    public int decrementSpawnRateTime = 60;
    public int spawnRate = 10;
    public int minimumSpawnRate = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnRate < minimumSpawnRate) spawnRate = minimumSpawnRate;
        InvokeRepeating("decrementSpawnRate", spawnRate, decrementSpawnRateTime);
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnEnemy()
    {
        int index = Random.Range(0, spawnPositions.Length);
        Instantiate(enemy, spawnPositions[index], Quaternion.identity);
        Invoke("spawnEnemy", spawnRate);
    }

    private void decrementSpawnRate()
    {
        if (spawnRate > minimumSpawnRate) spawnRate--;
    }
}
