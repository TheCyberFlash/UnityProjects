using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private float spawnTimer;
    [SerializeField] private GameObject enemyPrefab;
    private float elapsedTime;
    [SerializeField] private List<GameObject> spawnPositions;

    private void Awake()
    {
        spawnTimer = Random.Range(1f, 3f);
    }
    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > spawnTimer)
        {
            elapsedTime = 0;

            GameObject newEnemy = (GameObject)Instantiate(enemyPrefab, spawnPositions[Random.Range(0, 3)].transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
