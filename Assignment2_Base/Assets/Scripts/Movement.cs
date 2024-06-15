using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;

    [SerializeField]
    private float speed = 3f;

    private bool gotSpeedBonus = false;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void EnableMovementEvent(float moveInput)
    {
        myRigidbody2D.velocity = new Vector2 (moveInput * speed, myRigidbody2D.velocity.y);
    }

    public void Sink()
    {
        myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, -speed);
    }

    public void ToogleSpeed(float multiplier)
    {
        if(!gotSpeedBonus)
        {
            speed *= multiplier;
            gotSpeedBonus = true;
        }
        else
        {
            speed /= multiplier;
            gotSpeedBonus = false;
        }
    }
}
