using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineSpawner : MonoBehaviour
{
    public static SubmarineSpawner Instance { get; private set; }

    [SerializeField]
    private SubmarineMovement submarinePrefab;

    [SerializeField]
    private List<int> spawnLane = new List<int>();

    [SerializeField]
    private int numberOfSubmarinesToSpawn = 3;

    private int randomSpawnLane;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < numberOfSubmarinesToSpawn; ++i)
        {
            SpawnSubmarine();
        }
    }

    private void DetermineSpawnPoint()
    {
        randomSpawnLane = Random.Range(0, spawnLane.Count);
        spawnLane.RemoveAt(randomSpawnLane);
        print(randomSpawnLane);
    }

    private void SpawnSubmarine()
    {
        DetermineSpawnPoint();
        SubmarineMovement submarineMovement = Instantiate
            (submarinePrefab, new Vector2(0f, spawnLane[randomSpawnLane]), Quaternion.identity);
    }
}
