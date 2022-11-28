using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float spawnInterval = 30f;

    List<EnemySpawner> allSpawners = new List<EnemySpawner>();

    void Awake()
    {
        allSpawners = FindObjectsOfType<EnemySpawner>().ToList();
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < allSpawners.Count; i++)
        {
            if (allSpawners[i].SpawnedEnemyKilled)
            {
                allSpawners[i].SpawnEnemy();
            }
            yield return null;
        }
    }
}
