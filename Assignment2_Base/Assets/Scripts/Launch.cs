using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    [SerializeField]
    private DepthCharge depthChargePrefab;

    [SerializeField]
    private Transform spawnPoint;

    private float depthChargeMaxCapacity = 10f;

    private float depthChargeStock = 0f;

    private void Start()
    {
        depthChargeStock = depthChargeMaxCapacity;
    }

    public void SpawnDepthCharge()
    {
        if (0f < depthChargeStock && depthChargeStock <= depthChargeMaxCapacity)
        {
            DepthCharge depthCharge = Instantiate(depthChargePrefab, spawnPoint.position, spawnPoint.rotation);
            depthChargeStock = depthChargeStock - 1f;
        }
    }


}
