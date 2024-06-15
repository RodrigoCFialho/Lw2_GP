using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D myRigidBody2D;

    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private float wallDetectionTime = 0.1f;

    [SerializeField]
    private Transform wallDetectionPoint;

    [SerializeField]
    private Vector2 wallDetectionSize = new Vector2(0.1f, 1f);

    [SerializeField]
    private LayerMask wallLayerMask;

    private bool isDead = false;

    private void Start()
    {
        StartCoroutine(CheckWalls());
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            myRigidBody2D.velocity = new Vector2(transform.right.x * speed, myRigidBody2D.velocity.y);
        }
    }

    private IEnumerator CheckWalls()
    {
        WaitForSeconds waitTime = new WaitForSeconds(wallDetectionTime);
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.layerMask = wallLayerMask;
        contactFilter.useLayerMask = true;

        Collider2D[] results = new Collider2D[1];

        while (true)
        {
            yield return waitTime;

            if (Physics2D.OverlapBox(wallDetectionPoint.position, wallDetectionSize,
                0f, contactFilter, results) > 0)
            {
                transform.right = -transform.right;
            }
        }
    }

    public bool StopMoving()
    {
        return isDead = true;
    }
}
