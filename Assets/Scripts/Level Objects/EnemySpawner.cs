using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;

    // true if the last enemy spawned has been killed. False if it is still alive.
    public bool SpawnedEnemyKilled { get; private set; } = true;
    
    ShipHealth spawnedHealth;

    public void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = Instantiate(enemyPrefabs[index], transform.position, transform.rotation);
        spawnedHealth = enemy.GetComponent<ShipHealth>();
        spawnedHealth.OnShipSink.AddListener(SetSpawnedAsDead);
    }

    public void SetSpawnedAsDead()
    {
        SpawnedEnemyKilled = true;
    }
}
