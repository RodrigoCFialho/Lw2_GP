using UnityEngine;

public class DepthCharge : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LowerLimit") || collision.gameObject.CompareTag("Submarine") || collision.gameObject.CompareTag("Mine"))
        {
            gameObject.GetComponent<ExplosionEffect>().Explode();
        }
    }

    public void Dismiss()
    {
        PoolManager.Instance.DepthChargePool.Release(gameObject);
    }
}
