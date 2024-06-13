using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mines : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)  //talvez precise de ser virtual para a mina spetial
    {
        Explode();

        if (other.gameObject.CompareTag("Player"))
        {
            OnContact(other.gameObject);
        }
    }

    protected abstract void OnContact(GameObject player);

    protected void Explode()
    {
        Destroy(gameObject);
    }
}
