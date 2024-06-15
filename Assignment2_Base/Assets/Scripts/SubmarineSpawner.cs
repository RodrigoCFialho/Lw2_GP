using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SubmarineSpawner : MonoBehaviour
{
    public static SubmarineSpawner Instance { get; private set; }

    [SerializeField]
    private SubmarineMovement submarinePrefab;

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
        for (int i = 0; i < 3; ++i)
        {
            SpawnSubmarine();
        }
    }

    private void SpawnSubmarine()
    {
        float xSpawnValue = UnityEngine.Random.Range(-5f, 5f);

        int spawnLaneChance = UnityEngine.Random.Range(0, 4);
        int lane;
        if (spawnLaneChance == 0)
        {
            lane = -4;
        }
        else if (spawnLaneChance == 1)
        {
            lane = -3;
        }
        else if (spawnLaneChance == 2)
        {
            lane = -2;
        }
        else
        {
            lane = -1;
        }

        int flipChance = UnityEngine.Random.Range(0, 2);
        Quaternion submarineRotation;
        if (flipChance == 0)
        {
            submarineRotation = transform.rotation;
        }
        else
        {
            transform.Rotate(0f, 180f, 0f);
            submarineRotation = transform.rotation;
        }

        SubmarineMovement submarineMovement = Instantiate
            (submarinePrefab, new Vector2(xSpawnValue, lane), submarineRotation);
    }
}
