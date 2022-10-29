using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject[] doors;
    [SerializeField] private GameObject[] spawnPoints;
    private GameObject[] enemies;
    private EnemySpawner enemySpawner;
    [SerializeField] private float enemySpawnTimer;
    private float elapsedTime;
    private int enemyCount;
    private int spawnedCount;
    private int totalEnemyCount;

    public bool isClear;

    private void Awake()
    {
        totalEnemyCount = Random.Range(5, 25);
        Debug.Log(totalEnemyCount);

    }

    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemySpawner>();
        enemyCount = totalEnemyCount;
        enemies = enemySpawner.enemies;
        isClear = false;
        OpenDoors();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isClear && spawnedCount < totalEnemyCount)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > enemySpawnTimer)
            {
                elapsedTime = 0;

                var enemyIndex = Random.Range(0, enemies.Length);
                var spawnIndex = Random.Range(0, spawnPoints.Length);
                SpawnEnemy(enemyIndex, spawnIndex);
            }
        }
    }

    void SpawnEnemy(int enemyIndex, int spawnIndex)
    {
        Instantiate(enemies[enemyIndex], spawnPoints[spawnIndex].transform.position, Quaternion.identity);
        spawnedCount++;
    }

    void OpenDoors()
    {
        foreach (var door in doors)
        {
            door.SetActive(!isClear);
        }
    }

}
