using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private UnityEvent<int, int> OnTakeDamage;

    [SerializeField]
    private UnityEvent OnDie;

    private int health = 100;

    [SerializeField]
    private int maxHealth = 100;

    private void Awake()
    {
        maxHealth = health;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        health = maxHealth;
        UpdateHealthUi();
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

        UpdateHealthUi();
    }

    private void UpdateHealthUi()
    {
        UiManager.Instance.UpdateHealthBar(health);
    }

    private void Die()
    {
        //myRigidbody.simulated = false;
        OnDie.Invoke();
    }
}
