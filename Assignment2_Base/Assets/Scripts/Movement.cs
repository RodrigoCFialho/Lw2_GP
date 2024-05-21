using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;

    [SerializeField]
    private float speed = 3f;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void EnableMovementEvent(float moveInput)
    {
        // movement
        myRigidbody2D.velocity = new Vector2 (moveInput * speed, myRigidbody2D.velocity.y);
    }
}
