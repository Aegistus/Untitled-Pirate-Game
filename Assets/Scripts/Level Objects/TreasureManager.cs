using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    [SerializeField] GameObject treasureMapPrefab;
    [SerializeField] GameObject smallChestPrefab;    
    [SerializeField] GameObject mediumChestPrefab;    
    [SerializeField] GameObject largeChestPrefab;
    [SerializeField] float spawnDelay = 3f;

    public static TreasureManager Instance { get; private set; }

    // how many maps the player has currently spawned
    int foundTreasureMaps = 0;
    // how many maps the player must find before a chest spawns
    int mapsPerChest = 3;
    int numOfConcurrentChests = 3;
    List<TreasureMap> spawnedTreasureMaps;
    List<TreasureChest> spawnedTreasureChests;
    WorldBoundary worldBoundary;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        worldBoundary = FindObjectOfType<WorldBoundary>();
    }

    void Start()
    {
        //StartCoroutine(MapSpawnDelay());
        for (int i = 0; i < numOfConcurrentChests; i++)
        {
            SpawnTreasureMaps();
        }
    }

    void SpawnTreasureMaps()
    {
        for (int i = 0; i < mapsPerChest; i++)
        {
            GameObject map = Instantiate(treasureMapPrefab, worldBoundary.GetRandomPointInBounds(), Quaternion.identity);
            map.GetComponent<TreasureMap>().OnMapFound += UpdateMapCounter;
        }
    }

    void SpawnTreasureChest()
    {
        int random = Random.Range(0, 3);
        GameObject chest = null;
        switch (random)
        {
            case 0: chest = smallChestPrefab; break;
            case 1: chest = mediumChestPrefab; break;
            case 2: chest = largeChestPrefab; break;
        }
        Instantiate(chest, worldBoundary.GetRandomPointInBounds(), Quaternion.identity);
        foundTreasureMaps = 0;
        StartCoroutine(MapSpawnDelay());
    }
    
    void UpdateMapCounter()
    {
        foundTreasureMaps++;
        if (foundTreasureMaps >= mapsPerChest)
        {
            SpawnTreasureChest();
        }
    }

    IEnumerator MapSpawnDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        SpawnTreasureMaps();
    }
}
