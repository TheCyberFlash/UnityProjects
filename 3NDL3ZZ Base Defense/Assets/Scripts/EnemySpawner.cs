using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject[] enemies;
    private int enemyCount;
    
    public void SpawnNextWave()
    {
        var minCount = levelManager.waves * 5;
        var maxCount = levelManager.waves * 10;
        enemyCount = Mathf.RoundToInt(Random.Range(minCount, maxCount));
        levelManager.enemyCount = enemyCount;
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var enemyIndex = Mathf.RoundToInt(Random.Range(0, enemies.Length - 1));
        Instantiate(enemies[enemyIndex], transform.position, Quaternion.identity);
    }
}
