using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStartButton : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private EnemySpawner enemySpawner;

    private void OnMouseDown()
    {
        if (!levelManager.waveActive)
        {
            levelManager.waveActive = true;
            enemySpawner.SpawnNextWave();
        }
    }
}
