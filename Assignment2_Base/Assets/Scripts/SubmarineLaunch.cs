using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineLaunch : MonoBehaviour, ILaunchable
{
    private WaitForSeconds waitTime;

    [SerializeField]
    private float minimumPossibleTime = 0f;

    [SerializeField]
    private float maximumPossibleTime = 10f;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private GameObject blackMinePrefab;

    [SerializeField]
    private GameObject redMinePrefab;

    [SerializeField]
    private GameObject purpleMinePrefab;

    [SerializeField]
    private GameObject blueMinePrefab;

    private void Start()
    {
        waitTime = new WaitForSeconds(Random.Range(minimumPossibleTime, maximumPossibleTime));
        StartCoroutine(LaunchTimer());
    }

    private IEnumerator LaunchTimer()
    {
        while (true)
        {
            yield return waitTime;
            Launch();
        }
    }

    public void Launch()
    {
        waitTime = new WaitForSeconds(Random.Range(minimumPossibleTime, maximumPossibleTime));

        int spawnedMine = Random.Range(0, 4);

        if (spawnedMine == 0)
        {
            GameObject blackMine = Instantiate(blackMinePrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else if (spawnedMine == 1)
        {
            GameObject redMine = Instantiate(redMinePrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else if (spawnedMine == 2)
        {
            GameObject purpleMine = Instantiate(purpleMinePrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            GameObject blueMine = Instantiate(blueMinePrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
