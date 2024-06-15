using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float speed = 2f;

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
            SpawnRandomMine();
        }
    }

    private void SpawnRandomMine()
    {
        GameObject mine = PoolManager.Instance.MinePool.Get();
        mine.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
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
