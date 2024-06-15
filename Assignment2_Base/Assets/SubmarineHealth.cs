using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubmarineHealth : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnDie;

    private int health = 20;

    [SerializeField]
    private int maxHealth = 20;

    private void Start()
    {
        health = maxHealth;
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

            if (health == 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        gameObject.GetComponent<SubmarineMovement>().StopMoving();
        OnDie.Invoke();
    }

    public void Dismiss()
    {
        Destroy(gameObject);
        SubmarineSpawner.Instance.SpawnSubmarine();
    }
}
