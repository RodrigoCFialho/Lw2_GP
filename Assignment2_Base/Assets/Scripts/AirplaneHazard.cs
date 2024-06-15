using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneHazard : MonoBehaviour
{
    [SerializeField]
    private Airplane airplanePrefab;

    [SerializeField]
    private float timeBetweenSpawns = 10f;

    [SerializeField]
    private Transform leftSpawnPoint;

    [SerializeField]
    private Transform rightSpawnPoint;

    private void Start()
    {
        StartCoroutine(AirplaneSpawnTimer());
    }

    private IEnumerator AirplaneSpawnTimer()
    {
        WaitForSeconds waitTime = new WaitForSeconds(timeBetweenSpawns);

        while (true)
        {
            yield return waitTime;

            SpawnAirplane();
        }
    }

    private void SpawnAirplane()
    {
        int spawnLocation = Random.Range(0, 2);

        if (spawnLocation == 0)
        {
            Airplane airplane = Instantiate(airplanePrefab, leftSpawnPoint);
        }
        else
        {
            Airplane airplane = Instantiate(airplanePrefab, rightSpawnPoint);
        }
    }
}
