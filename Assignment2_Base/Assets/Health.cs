using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private UnityEvent<int, int> OnTakeDamage;

    [SerializeField]
    private UnityEvent OnDie;

    [SerializeField]
    private int health = 100;

    private int maxHealth;

    private void Awake()
    {
        maxHealth = health;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health < 0)
            {
                health = 0;
            }

            OnTakeDamage.Invoke(health, maxHealth);

            if (health == 0)
            {
                Die();
            }
        }
    }
    private void Die()
    {
        //myRigidbody.simulated = false;
        OnDie.Invoke();
    }
}
