using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance {  get; private set; }

    public IObjectPool<GameObject> DepthChargePool { get; private set;}

    [SerializeField] List<PooledItem> poolItems = new List<PooledItem>();

    [SerializeField]
    private GameObject depthChargePrefab;

    [SerializeField]
    private bool collectionChecks = true;

    [SerializeField]
    private int initialPoolAmount = 5;

    [SerializeField]
    private int defaultCollectionSize = 5;

    [SerializeField]
    private int maxPoolSize = 10;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            CreatePool();
            CreateInitialDepthCharges();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CreatePool()
    {
        DepthChargePool = new ObjectPool<GameObject>(
            CreateDepthCharge,
            OnTakeFromPool,
            OnReturnedToPool,
            OnDestroyPoolObject,
            collectionChecks,
            defaultCollectionSize,
            maxPoolSize);
    }

    private void CreateInitialDepthCharges()
    {
        for (int i = 0; i < initialPoolAmount; ++i)
        {
            DepthChargePool.Release(CreateDepthCharge());
        }
    }

    private GameObject CreateDepthCharge()
    {
        return Instantiate(depthChargePrefab, transform);
    }

    private void OnTakeFromPool(GameObject depthCharge)
    {
        depthCharge.SetActive(true);
    }

    private void OnReturnedToPool(GameObject depthCharge)
    {
        depthCharge.SetActive(false);
    }

    private void OnDestroyPoolObject(GameObject depthCharge)
    {
        Destroy(depthCharge);
    }
}
