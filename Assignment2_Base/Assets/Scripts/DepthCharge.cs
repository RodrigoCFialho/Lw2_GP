using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthCharge : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    [SerializeField]
    private float speed = 3f;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        myRigidbody2D.velocity = new Vector2 (myRigidbody2D.velocity.x, -speed);
    }
}
