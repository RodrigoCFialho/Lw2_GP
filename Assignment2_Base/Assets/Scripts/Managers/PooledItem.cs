using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PooledItem
{
    [field: SerializeField]
    public GameObject objectToPool { get; private set; }

    [field: SerializeField]
    public int maxPoolSize { get; private set; }

    [field: SerializeField]
    public int defaultPoolSize { get; private set; }

    public PooledItem(GameObject objectToPool, int maxPoolSize, int defaultPoolSize)
    {
        this.objectToPool = objectToPool;
        this.maxPoolSize = maxPoolSize;
        this.defaultPoolSize = defaultPoolSize;
    }
}