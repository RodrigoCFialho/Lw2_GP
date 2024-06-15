using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMine : Mines
{
    [SerializeField]
    private float effectDuration = 6f;

    private Coroutine myCoroutine = null;
    
    protected override void OnCollisionEnter2D(Collision2D other)
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sky"))
        {
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
}
