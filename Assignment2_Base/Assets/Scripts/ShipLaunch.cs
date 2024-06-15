using UnityEngine;

public class ShipLaunch : MonoBehaviour, ILaunchable
{
    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float depthChargeSpeed = 3f;

    [SerializeField]
    private int depthChargeMaxCapacity = 10;

    private int depthChargeStock = 0;

    private void Start()
    {
        RestoreStock();
    }

    public void Launch()
    {
        if (0f < depthChargeStock && depthChargeStock <= depthChargeMaxCapacity)
        {
            GameObject depthCharge = PoolManager.Instance.DepthChargePool.Get();
            depthCharge.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
            depthCharge.GetComponent<Rigidbody2D>().velocity = new Vector2(depthCharge.GetComponent<Rigidbody2D>().velocity.x, -depthChargeSpeed);

            depthChargeStock -= 1;
            UiManager.Instance.UpdateDepthChargeText(depthChargeStock, depthChargeMaxCapacity);
        }
    }

    public void RestoreStock()
    {
        depthChargeStock = depthChargeMaxCapacity;
        UiManager.Instance.UpdateDepthChargeText(depthChargeStock, depthChargeMaxCapacity);
    }
}
