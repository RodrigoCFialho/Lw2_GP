using UnityEngine;

public class DepthCharge : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    private CapsuleCollider2D myCapsuleCollider2D;

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LowerLimit") || collision.gameObject.CompareTag("Submarine") || collision.gameObject.CompareTag("Mine"))
        {
            gameObject.GetComponent<ExplosionEffect>().Explode();
            myRigidBody.simulated = false;
            myCapsuleCollider2D.enabled = false;
        }
    }

    public void Dismiss()
    {
        PoolManager.Instance.DepthChargePool.Release(gameObject);
        myRigidBody.simulated = true;
        myCapsuleCollider2D.enabled = true;
    }
}
