using UnityEngine;

public class DepthCharge : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    private CapsuleCollider2D myCapsuleCollider2D;

    [SerializeField]
    private int damage = 10;

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("LowerLimit") || other.gameObject.CompareTag("Mine"))
        {
            Collision();
        }
        else if (other.gameObject.CompareTag("Submarine"))
        {
            Collision();
            other.gameObject.GetComponent<SubmarineHealth>().TakeDamage(damage);
        }
    }

    private void Collision()
    {
        gameObject.GetComponent<ExplosionEffect>().Explode();
        myRigidBody.simulated = false;
        myCapsuleCollider2D.enabled = false;
    }

    public void Dismiss()
    {
        PoolManager.Instance.DepthChargePool.Release(gameObject);
        myRigidBody.simulated = true;
        myCapsuleCollider2D.enabled = true;
    }
}
