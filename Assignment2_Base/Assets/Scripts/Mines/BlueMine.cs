using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMine : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    private CircleCollider2D myCircleCollider2D;

    [SerializeField]
    private float effectDuration = 6f;

    private Coroutine myCoroutine = null;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myCircleCollider2D = GetComponent<CircleCollider2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (myCoroutine == null)
            {
                myCoroutine = StartCoroutine(DisableShootAbility());
            }
            else
            {
                StopCoroutine(myCoroutine);
                myCoroutine = StartCoroutine(DisableShootAbility());
            }

            Explode();
        }
    }

    private IEnumerator DisableShootAbility()
    {
        WaitForSeconds waitTime = new WaitForSeconds(effectDuration);

        InputSystem.Instance.DisablePlayerLaunch();

        while (true)
        {
            yield return waitTime;

            InputSystem.Instance.EnablePlayerLaunch();
            break;
        }
    }

    public void Explode()
    {
        gameObject.GetComponent<ExplosionEffect>().Explode();
        myRigidbody2D.simulated = false;
        myCircleCollider2D.enabled = false;
    }

    public void Dismiss()
    {
        Destroy(gameObject);
    }
}
