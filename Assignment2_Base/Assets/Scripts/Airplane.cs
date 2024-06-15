using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour, ILaunchable
{
    private Rigidbody2D myRigidbody2D;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private GameObject blackMinePrefab;

    [SerializeField]
    private GameObject yellowMinePrefab;

    [SerializeField]
    private GameObject specialMinePrefab;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        myRigidbody2D.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Launch();
        }
    }

    public void Launch()
    {
        int spawnedMine = Random.Range(0, 3);

        if (spawnedMine == 0)
        {
            GameObject blackMine = Instantiate(blackMinePrefab, spawnPoint.position, spawnPoint.rotation);
            blackMine.GetComponent<Rigidbody2D>().gravityScale *= -1;
        }
        else if (spawnedMine == 1)
        {
            GameObject yellowMine = Instantiate(yellowMinePrefab,spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            GameObject specialMine = Instantiate(specialMinePrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Sky"))
        {
            Dismiss();
        }
    }

    private void Dismiss()
    {
        Destroy(gameObject);
    }
}
